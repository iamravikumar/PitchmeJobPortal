﻿using PitchMe.App_Start;
using System.Web;
using System.Web.Mvc;

namespace PitchMe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
