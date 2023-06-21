using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCRUD2.Controllers
{
    public class BaseController:Controller
    {
        public string CurrentUser
        {
            get
            {
                return HttpContext.Session.GetString("USER_NAME");
            }
            set
            {
                HttpContext.Session.SetString("USER_NAME", value);
            }
        }
        public bool IsLogin
        {
            get
            {
                return !string.IsNullOrEmpty(CurrentUser);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
       
}
