using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;


namespace B2000_AbpEf.Module
{
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class B2000_AbpEfAbpModule : AbpModule
    {

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "B2000_AbpEfDbContext";
        }


        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
