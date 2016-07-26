using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Drawing;
using System.Drawing.Imaging;


namespace A1060_ImageProperty.Sample
{


    public class ImagePropertyReader
    {

        private Image image1;


        public ImagePropertyReader(string imageFileName)
        {
            image1 = Image.FromFile(imageFileName);
        }




        public void ShowPropertyItem(int id)
        {

            try
            {
                PropertyItem propItem = image1.GetPropertyItem(id);

                Console.WriteLine("PropertyItem: [ ID={0};Value={1} ]", 
                    propItem.Id, propItem.GetDisplayValue());

                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("该图像的图像格式不支持属性项 {0}。", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生了异常 {0}", ex.Message);
            }

        }

    }



    /// <summary>
    /// 本类为，我们为那些 “不能直接修改的类”
    /// 额外追加的方法。
    /// </summary>
    public static class MyExtensionMethods
    {

        public static string GetDisplayValue(this PropertyItem propItem)
        {

            string result = null;

            // https://msdn.microsoft.com/zh-cn/library/system.drawing.imaging.propertyitem.type(v=vs.110).aspx
            switch (propItem.Type)
            {

                case 1:
                    // 指定 Value 为字节数组。
                    break;

                case 2:
                    // 指定 Value 为空终止 ASCII 字符串。 如果将类型数据成员设置为 ASCII 类型，则应该将 Len 属性设置为包括空终止的字符串长度。 例如，字符串“Hello”的长度为 6。 

                    result =  String.Format(System.Text.Encoding.ASCII.GetString(propItem.Value));
                    break;

                case 3:
                    // 指定 Value 为无符号的短（16 位）整型数组。
                    result = String.Format("{0}", propItem.Value[0] | propItem.Value[1] << 8);
                    break;

                case 4:
                    // 指定 Value 为无符号的短（32 位）整型数组。
                    result = String.Format("{0}",
                        (uint)(propItem.Value[0] 
                        | propItem.Value[1] << 8
                        | propItem.Value[2] << 16
                        | propItem.Value[3] << 24));
                    break;

                case 5:
                    // 指定 Value 数据成员为无符号的长整型对数组。 每一对都表示一个分数；第一个整数是分子，第二个整数是分母。 

                    int valueLen = propItem.Value.Length;

                    StringBuilder buff = new StringBuilder();

                    for(int i = 0; i < valueLen; i += 8)
                    {
                        uint firstVal = GetUintValue(propItem.Value, i);
                        uint secondVal = GetUintValue(propItem.Value, i + 4);
                        buff.AppendFormat("{0}/{1},", firstVal, secondVal);
                    }

                    if (buff.Length > 0)
                    {
                        buff.Length = buff.Length - 1;
                    }

                    result = buff.ToString();
                    
                    break;

                case 6:
                    // 指定 Value 为可以包含任何数据类型的值的字节数组。
                    result = String.Format("TODO...Type 6");
                    break;

                case 7:
                    // 指定 Value 为有符号的长（32 位）整型数组。
                    result = String.Format("{0}",
                        (int)(propItem.Value[0]
                        | propItem.Value[1] << 8
                        | propItem.Value[2] << 16
                        | propItem.Value[3] << 24));
                    break;

                case 10:
                    // 指定 Value 为有符号的长整型对数组。 每一对都表示一个分数；第一个整数是分子，第二个整数是分母。 
                    result = String.Format("TODO...Type 10");
                    break;

                default:
                    result = String.Format("Unknow Type {0}", propItem.Type);
                    break;
            }


            return result;
        }



        /// <summary>
        /// byte 数组转换为 uint.
        /// </summary>
        /// <param name="bArray"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static uint GetUintValue(byte[] bArray, int startIndex = 0)
        {
            uint resultVal = (uint)(bArray[startIndex] | bArray[startIndex + 1] << 8
                                        | bArray[startIndex + 2] << 16 | bArray[startIndex + 3] << 24);

            return resultVal;
        }


    }

}
