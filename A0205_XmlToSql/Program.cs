using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

using A0205_XmlToSql.Model;



namespace A0205_XmlToSql
{
    class Program
    {
        static void Main(string[] args)
        {


            XmlSerializer xs = new XmlSerializer(typeof(Provinces));
            StreamReader sr = new StreamReader("Provinces.xml");
            Provinces provinces = xs.Deserialize(sr) as Provinces;
            sr.Close();

            foreach (Province p in provinces.ProvinceArray)
            {
                Console.WriteLine(
                    @"INSERT INTO Provinces (Province_ID, Province_Name) VALUES ({0}, '{1}') ;",
                    p.ID,
                    p.ProvinceName);
            }


            Console.WriteLine();

            xs = new XmlSerializer(typeof(Cities));
            sr = new StreamReader("Cities.xml");
            Cities cities = xs.Deserialize(sr) as Cities;
            sr.Close();

            foreach (City c in cities.CityArray)
            {
                Console.WriteLine(
                    @"INSERT INTO City (City_id, Province_ID, City_Name, City_ZipCode) VALUES ({0}, {1}, '{2}', '{3}') ;",
                    c.ID,
                    c.PID,
                    c.CityName,
                    c.ZipCode);
            }

            Console.WriteLine();


            xs = new XmlSerializer(typeof(Districts));
            sr = new StreamReader("Districts.xml");
            Districts districts = xs.Deserialize(sr) as Districts;
            sr.Close();


            foreach (District d in districts.DistrictArray)
            {
                Console.WriteLine(
                    @"INSERT INTO District (District_ID, City_ID, District_Name) VALUES ({0}, {1}, '{2}') ;",
                    d.ID,
                    d.CID,
                    d.DistrictName);
            }


            // 通过重定向，产生 .sql 文件
            // A0205_XmlToSql.exe >> test.sql
        }
    }
}
