using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;



using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;


using W1050_Mvc5.Controllers;



namespace W1050_Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DisplayConfig.RegisterDisplayModes(DisplayModeProvider.Instance.Modes);



            // 在 IIS 8 当中，进行如下的设置:
            // 1.Application Pool层级:只要有需要的Application Pool的Start Mode设定AlwaysRunning就可以。
            // 2.Web Site层级:选择要做Preload的Web Site。 开启preload和DoAppInitAfterRestart。



            // ##### EF Pre-Generated Mapping Views #####

            // 由于 EF 在首次加载的时候， 非常耗时
            // 因此，初始化的操作， 放置在 Application_Start 里面进行处理。
            // 这样一来， 首次查询操作， 将不会发生速度非常慢的现象。
      
            // 对程序中定义的所有DbContext逐一进行这个操作
            using (var dbcontext = new MyTestContext())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }  


            
        }










    }



}
