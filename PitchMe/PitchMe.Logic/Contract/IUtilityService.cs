using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PitchMe.Services.Contract
{
    public interface IUtilityService
    {
        IDictionary<string, string> SaveImageToFolder(HttpPostedFileBase file, string serverPath, string defaultImgPath);
    }
}
