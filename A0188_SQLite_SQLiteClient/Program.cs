using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0188_SQLite_SQLiteClient.Sample;


namespace A0188_SQLite_SQLiteClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // 读
            ReadSQLiteData reader = new ReadSQLiteData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();

            // 写.
            WriteSQLiteData writer = new WriteSQLiteData();
            writer.TestInsertUpdateDelete();


            Console.ReadLine();

        }
    }
}
