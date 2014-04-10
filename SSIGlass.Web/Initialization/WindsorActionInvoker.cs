using System.Collections.Generic;
using System.Web.Mvc;

namespace SSIGlass.Web.Initialization
{
    using Castle.MicroKernel;

    public class WindsorActionInvoker : ControllerActionInvoker
    {
        private readonly IKernel _container;

        public WindsorActionInvoker(IKernel container)
        {
            _container = container;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            foreach (var filter in filters)
            {
                _container.InjectProperties(filter);
            }
            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }
    }
}