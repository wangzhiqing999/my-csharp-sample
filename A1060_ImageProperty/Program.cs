using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A1060_ImageProperty.Sample;


namespace A1060_ImageProperty
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowImageInfo("IMG_0096.JPG");
            ShowImageInfo("124816.jpg");

            Console.ReadLine();
        }




        static void ShowImageInfo(string fileName)
        {

            ImagePropertyReader reader = new ImagePropertyReader(fileName);

            // 拍摄时间.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagDateTime);

            // 拍照的程序名称.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagSoftwareUsed);

            // 图像尺寸.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagExifPixXDim);
            reader.ShowPropertyItem(PropertyTagID.PropertyTagExifPixYDim);

            // 水平分辨率.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagXResolution);
            // 垂直分辨率.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagYResolution);


            // 照相机制造商.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagEquipMake);

            // 照相机型号.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagEquipModel);

            // 光圈值.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagExifFNumber);

            // 曝光时间.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagExifExposureTime);

            // ISO.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagExifISOSpeed);


            // 纬度.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsLatitudeRef);
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsLatitude);


            // 经度.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsLongitudeRef);
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsLongitude);


            // 高度.
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsAltitudeRef);
            reader.ShowPropertyItem(PropertyTagID.PropertyTagGpsAltitude);


            Console.WriteLine();
        }

    }
}
