using Pitchme.Models.Implementation;
using PitchMe.Models.Implementation;
using PitchMe.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PitchMe.Services.Contract
{
    public interface IResumeService
    {
        Resume SaveNewResume(User user, EditResumeViewModel model);
        void UpdateExistingResume(Resume theResume, EditResumeViewModel model);
        //IDictionary<string, string> SaveImageToFolder(HttpPostedFileBase file, string serverPath, string defaultImgPath);
    }
}
