using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;


namespace MyWCFDataService
{
    public class DemoWcfDataService : DataService<TestEntities>
    {
        // 仅调用此方法一次以初始化涉及服务范围的策略。
        public static void InitializeService(DataServiceConfiguration config)
        {

            
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);




            // 上面是 允许全部访问的 代码
            // 实际应用中， 这么写， 是不合适的.


            // ========================================

            //public void SetEntitySetAccessRule(
            //    string name,
            //    EntitySetRights rights
            //)
            // name : 要为其设置权限的实体集的名称
            // rights : 要授予此资源的访问权限


            // EntitySetRights 枚举
            //成员名称		说明
            //None			拒绝所有数据访问权限。
            //ReadSingle		授权读取单一数据项。
            //ReadMultiple	授权读取数据集。
            //WriteAppend		授权在数据集中创建新数据项。
            //WriteReplace	授权替换数据。
            //WriteDelete		授权从数据集中删除数据项。
            //WriteMerge		授权合并数据。
            //AllRead			授权读取数据。
            //AllWrite		授权写入数据。
            //All				授权创建、读取、更新和删除数据。 


            // ========================================





            //public void SetServiceOperationAccessRule(
            //    string name,
            //    ServiceOperationRights rights
            //)
            // name : 要为其设置权限的服务操作的名称。
            // rights : 要授予此资源的访问权限，可作为 ServiceOperationRights 值传递。


            // ServiceOperationRights 枚举
            //成员名称					说明
            //None						未授权访问服务操作。
            //ReadSingle					授予通过使用服务操作读取一个数据项。
            //ReadMultiple				授予通过使用服务操作读取多个数据项。
            //AllRead						授权读取服务操作所部署的一个或多个数据项。
            //All							分配给服务操作的所有权限。
            //OverrideEntitySetRights		使用服务操作权限重写在数据服务中显式定义的实体集权限。





            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
