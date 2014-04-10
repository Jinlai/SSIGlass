using System;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin.Controllers
{
    using Contract.Services;
    using ViewModels;
    using Helpers;
    using Infrastructure.Mvc.ActionResults;

    public class CustomContentController : Controller
    {
        //
        // GET: /Admin/CustomContent/
        private readonly ICustomContentService _customContentService;
        private readonly CustomContentMenuItemProvider _menuItemProvider;

        public CustomContentController(ICustomContentService customContentService, CustomContentMenuItemProvider menuItemProvider)
        {
            _customContentService = customContentService;
            _menuItemProvider = menuItemProvider;
        }

        #region Default
        public ActionResult Default(string groupName)
        {
            var model = new CustomContentViewModel
                            {
                                Items = _menuItemProvider.GetItems(groupName) ?? new string[] { },
                                GroupName = groupName,
                            };

            return View(model);
        }
        #endregion

        #region Edit
        public ActionResult Edit(string groupName, string key)
        {
            var contentKey = string.Format("{0}_{1}", groupName, key);
            var content = _customContentService.Get(contentKey);

            var model = new CustomContentViewModel
            {
                GroupName = groupName,
                Key = key,
                Content = content
            };
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(CustomContentViewModel model)
        {
            model.Content = HttpUtility.UrlDecode(model.Content);
            var result = new AjaxResult();
            try
            {
                var contentKey = string.Format("{0}_{1}", model.GroupName, model.Key);
                _customContentService.Set(contentKey, model.Content);
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ErrorMessage = exception.Message;
            }
            return Json(result);
        }
        #endregion
    }
}