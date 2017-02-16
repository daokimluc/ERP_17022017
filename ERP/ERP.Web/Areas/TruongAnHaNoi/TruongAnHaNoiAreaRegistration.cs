using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHaNoi
{
    public class TruongAnHaNoiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TruongAnHaNoi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TruongAnHaNoi_default",
                "TruongAnHaNoi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}