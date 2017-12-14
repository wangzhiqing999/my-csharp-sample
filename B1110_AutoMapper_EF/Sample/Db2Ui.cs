using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


using B1110_AutoMapper_EF.Model;
using B1110_AutoMapper_EF.DataAccess;
using B1110_AutoMapper_EF.UiModel;

namespace B1110_AutoMapper_EF.Sample
{


    public class Db2Ui
    {

        public Db2Ui()
        {
            // 初始化配置
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbVersion, UiVersion>()
                    // 版本表中，没有 产品名称列， 只有  产品代码。 这里需要手动定义关联。 (相当于 一对多的情况下，  多方获取一方数据的处理.)
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductData.ProductName));



                cfg.CreateMap<DbProduct, UiProduct>()
                    // 一对多的情况下，  一方获取多方数据的处理.
                    .ForMember(dest => dest.VersionList, opt => opt.MapFrom(src => Mapper.Map<List<DbVersion>, List<UiVersion>>(src.VersionList)));
                
            });
        }




        public void DoTest1()
        {

            using (MyVersionManagerContext context = new MyVersionManagerContext())
            {

                DbProduct dp = context.DbProducts.Find("TEST");
                UiProduct up = Mapper.Map<DbProduct, UiProduct>(source: dp);


                Console.WriteLine("DB TO UI ...");
                Console.WriteLine("DB = {0}", dp);
                Console.WriteLine("UI = {0}", up);
                Console.WriteLine("DB TO UI Finish.");



                DbVersion dv = dp.VersionList.LastOrDefault();
                UiVersion uv = Mapper.Map<DbVersion, UiVersion>(source: dv);

                Console.WriteLine("DB TO UI ...");
                Console.WriteLine("DB = {0}", dv);
                Console.WriteLine("UI = {0}", uv);



                List<DbVersion> dvList = dp.VersionList;
                List<UiVersion> uvList = Mapper.Map<List<DbVersion>, List<UiVersion>>(source: dvList);

                Console.WriteLine("DB List TO UI  List...");

                Console.WriteLine("DB List = ...");
                foreach (var item in dvList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("UI List = ...");
                foreach (var item in uvList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("DB TO UI Finish.");
            }

        }


    }


}
