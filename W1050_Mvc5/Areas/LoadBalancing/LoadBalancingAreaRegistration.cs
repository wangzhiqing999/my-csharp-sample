using System.Web.Mvc;

namespace W1050_Mvc5.Areas.LoadBalancing
{
    public class LoadBalancingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LoadBalancing";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LoadBalancing_default",
                "LoadBalancing/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}