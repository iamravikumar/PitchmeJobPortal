using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PitchMe.Models
{
    public static class CountryStates
    {
        static Dictionary<string, List<string>> countryStates = new Dictionary<string, List<string>>
        {
            {
                "Nigeria", new List<string>()
                {
                    "Abia", "Adamawa", "Akwa-Ibom", "Lagos", "FCT"
                }
            },

            {"Ghana", new List<string>()
                {
                    "Accra"
                }
            }
        };
        public static IEnumerable<SelectListItem> GetStates(string countryName)
        {
            var states = new List<string>();
            //var h = countryStates[countryName].AsEnumerable().Select(i =>
            //  new SelectListItem { Text = i, Value = i });
            if (countryStates.TryGetValue(countryName, out states))
            {

            }
            return states.AsEnumerable().Select(i =>  new SelectListItem { Text = i, Value = i });;
        }

    }
}