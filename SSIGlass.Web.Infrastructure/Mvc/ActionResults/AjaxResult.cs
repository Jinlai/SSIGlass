using System.Web.Mvc;

namespace SSIGlass.Web.Infrastructure.Mvc.ActionResults
{
    public class AjaxResult : ActionResult
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public object ReturnObject { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            
        }
    }
}