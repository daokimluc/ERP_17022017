using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnDaNang
{
    public class TruongAnDaNangAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TruongAnDaNang";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TruongAnDaNang_default",
                "TruongAnDaNang/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}