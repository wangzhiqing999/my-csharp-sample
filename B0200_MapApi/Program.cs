using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using B0200_MapApi.Sample;


namespace B0200_MapApi
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===== 使用阿里云地图查询 =====");

            // 初始化服务.
            AliyunMapServuce service = new AliyunMapServuce();
            // 查询.
            AliyunGeocodingResult aliyunResult = service.Geocoding("海淀知春路28号");
            // 输出结果.
            Console.WriteLine(aliyunResult);

            aliyunResult = service.Geocoding("上海市南京西路1168号");
            // 输出结果.
            Console.WriteLine(aliyunResult);




            Console.WriteLine("===== 使用百度地图查询 =====");

            BaiduMapService baiduService = new BaiduMapService();
            // 查询.
            BaiduGeocoderResult baiduResult = baiduService.Geocoding("北京市海淀区中关村南大街27号");
            // 输出结果.
            Console.WriteLine(baiduResult);


            baiduResult = baiduService.Geocoding("上海市南京西路1168号");
            // 输出结果.
            Console.WriteLine(baiduResult);

            Console.ReadLine();
        }
    }
}
