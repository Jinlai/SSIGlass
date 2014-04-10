using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSIGlass.Web.ViewModels
{
    using Contract.Models;

    public class HomeViewModel
    {
        public IList<Article> Articles { get; set; }
    }
}