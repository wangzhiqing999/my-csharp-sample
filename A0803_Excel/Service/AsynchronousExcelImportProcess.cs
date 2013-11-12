using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.OleDb;


namespace A0803_Excel.Service
{

    /// <summary>
    /// 异步 Excel 数据导入处理类.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class AsynchronousExcelImportProcess<T1, T2>
        where T1 : ExcelDataImportFormater<T2>    
    {


        /// <summary>
        /// 小部分数据读取的事件.
        /// </summary>
        /// <param name="dataList"></param>
        public delegate void DataReaderStepHandler(List<T2> dataList);

        /// <summary>
        /// 数据处理完毕的事件.
        /// </summary>
        public delegate void DataReaderFinishHandler();



        #region 外部事件.


        /// <summary>
        /// 当读取到数据时触发的事件.
        /// </summary>
        public DataReaderStepHandler DataReaderStep { set; get; }


        /// <summary>
        /// Excel 数据读取完毕.
        /// </summary>
        public DataReaderFinishHandler DataReaderFinish { set; get; }


        #endregion




        #region 外部属性.


        /// <summary>
        /// 基准的定义得对象.
        /// </summary>
        public T1 ExcelDataImportFormater { set; get; }

        /// <summary>
        /// 导出的 Excel 文件名称.
        /// </summary>
        public string InputFileName { set; get; }


        /// <summary>
        /// 窗口大小.
        /// </summary>
        public int WindowsSize
        {
            set;
            get;
        }

        #endregion





        public AsynchronousExcelImportProcess()
        {
            // 默认的 窗口大小.
            this.WindowsSize = 100;
        }
    



        /// <summary>
        /// 创建 Excel 报表.
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="outputFileName"></param>
        private void ReadExcelData()
        {

            // 取得连接字符串.
            String sConnectionString =
                Common.GetOleDbConnectionString(InputFileName);

            // 定义 Oledb 的数据库联接.
            OleDbConnection connection = new OleDbConnection(sConnectionString);
            

            try
            {
                // 打开数据库连接.
                connection.Open();

                // 获取数据库表配置定义.
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                // 创建一个 Command.
                OleDbCommand command = connection.CreateCommand();


                // 遍历每一个 “表”
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    // 取得表的定义的一行 DataRow.
                    DataRow dr = schemaTable.Rows[i];
                    // 取得表名称.
                    string tableName = dr["TABLE_NAME"].ToString().Trim('\'');
                    // 表名称的 有效性判断.
                    if (tableName.IndexOf("$") <= 0
                        || !tableName.EndsWith("$"))
                    {
                        // Sheet 名中不包含 $ 的，或者不是$ 结尾的。忽略.
                        continue;
                    }

                    // 定义需要执行的SQL语句.
                    command.CommandText = string.Format("SELECT * FROM [{0}]", tableName);

                    // 执行SQL命令，结果存储到Reader中.
                    OleDbDataReader reader = command.ExecuteReader();

                    // 缓冲记录.
                    List<T2> buffList = new List<T2>();

                    // 处理检索出来的每一条数据.
                    while (reader.Read())
                    {
                        // 将检索出来的数据，转换后并加入列表.
                        T2 oneData = ExcelDataImportFormater.GetDataFromDataReader(reader);

                        // 加入临时列表.
                        buffList.Add(oneData);

                        // 数据量达到窗口值得时候，写入列表.
                        if (buffList.Count >= this.WindowsSize)
                        {
                            // 根据需要 触发事件.
                            BuildTempList(buffList);
                        }
                    }

                    // 根据需要 触发事件.
                    BuildTempList(buffList);


                    // 关闭Reader.
                    reader.Close();

                }
                
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            if (DataReaderFinish != null)
            {
                DataReaderFinish();
            }
        }


        /// <summary>
        /// 根据需要 触发事件.
        /// </summary>
        /// <param name="buffList"></param>
        private void BuildTempList(List<T2> buffList)
        {
            if (buffList.Count > 0)
            {

                // 克隆一下 数据列表.
                List<T2> tmpList = new List<T2>();
                tmpList.AddRange(buffList);

                // 根据需要 触发事件.
                if (DataReaderStep != null)
                {
                    DataReaderStep(tmpList);
                }

                // 清空缓存.
                buffList.Clear();
            }
        }



        /// <summary>
        /// 开始异步处理.
        /// </summary>
        public void StartAsynchronousProcess()
        {
            Thread reader = new Thread(ReadExcelData);
            reader.Start();
        }

    }


}
