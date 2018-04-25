using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Models.Implementation;
using PitchMe.Models.ViewModels;
//using PitchMe.Data.Repository.Implementation;
using PitchMe.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PitchMe.Services.Implementation
{
    public class ResumeService : IResumeService
    {
        private IUnitOfWork uow;
        public ResumeService(IUnitOfWork _uow)
        {
            uow = _uow; 
        }
        public Resume SaveNewResume(User user, EditResumeViewModel model)
        {
            Resume resume = new Resume
            {
                FullName = model.FullName,
                AdditionalInformation = model.AdditionalInformation,
                Address = model.Address,
                CareerObjective = model.CareerObjective,
                DateOfBirth = model.DateOfBirth,
                Declaration = model.Declaration,
                FatherName = model.FatherName,
                Gender = model.Gender,
                MotherName = model.MotherName,
                Nationality = model.Nationality,
                PlaceOfBirth = model.PlaceOfBirth,
                ProfileImageUri = String.IsNullOrEmpty(model.ProfileImageUri) ? "~/assets/images/UserProfileImages/user.jpg" : model.ProfileImageUri,
                SkillsAndQualifications = model.SkillsAndQualifications,
                EducationBackgrounds = model.EducationBackgrounds,
                WorkExperiences = model.WorkExperiences,
                Languages = model.Languages, 
                DateCreated=DateTime.Now,
                DateModified=DateTime.Now
            };
            uow.resumeRepository.Add(resume);
            //theResume = resume;
            uow.userRepository.Update(user);
            return resume;
        }
        public void UpdateExistingResume(Resume theResume, EditResumeViewModel model)
        {
            if (theResume.EducationBackgrounds.Any()) //EDIT IT
            {
                UpdateEducationalBackgrounds(theResume, model);
            }
            else    //eduBackgrounds is null, create new if available in the model
            {
                AddEduBackgroundsFromViewModel(theResume, model);
            }

            if (theResume.WorkExperiences.Any())
            {
                UpdateWorkExperience(theResume, model);
            }
            else    //workexperiences is null, create new if available in the model
            {
                AddWorkExperienceFromViewModel(theResume, model);
            }
            AddOrUpdateLanguages(theResume, model);

            theResume.FullName = model.FullName;
            if (!String.IsNullOrEmpty(model.ProfileImageUri))
            {
                theResume.ProfileImageUri = model.ProfileImageUri;
            }
            
            theResume.DateOfBirth = model.DateOfBirth;
            theResume.AdditionalInformation = model.AdditionalInformation;
            theResume.Address = model.Address;
            theResume.CareerObjective = model.CareerObjective;
            theResume.PlaceOfBirth = model.PlaceOfBirth;
            theResume.SkillsAndQualifications = model.SkillsAndQualifications;
            theResume.Nationality = model.Nationality;
            theResume.Nationality = model.MotherName;
            theResume.Gender = model.Gender;
            theResume.FatherName = model.FatherName;
            theResume.Declaration = model.Declaration;
            theResume.MotherName = model.MotherName;
            theResume.DateModified = DateTime.Now;

            uow.resumeRepository.Update(theResume);
            //uow.userRepository.Update(user);
        }

      
       


        private void AddWorkExperienceFromViewModel(Resume theResume, EditResumeViewModel model)
        {
            if (model.WorkExperiences != null)
            {
                uow.workExperienceRepository.AddRange(model.WorkExperiences);
                theResume.WorkExperiences = model.WorkExperiences;
            }
        }

        private void UpdateWorkExperience(Resume theResume, EditResumeViewModel model)
        {
            List<long> workExpIds = uow.workExperienceRepository.Find(e => e.ResumeId == theResume.ID).AsQueryable().Select(e => e.ID).ToList();
            theResume.WorkExperiences.Clear();

            foreach (long id in workExpIds)
            {
                uow.workExperienceRepository.Remove(uow.workExperienceRepository.Get(id));
            }

            AddWorkExperienceFromViewModel(theResume, model);
        }

        private void AddEduBackgroundsFromViewModel(Resume theResume, EditResumeViewModel model)
        {
            if (model.EducationBackgrounds != null)
            {
                uow.educationBackgroundRepository.AddRange(model.EducationBackgrounds);
                theResume.EducationBackgrounds = model.EducationBackgrounds;
            }
        }

        private void UpdateEducationalBackgrounds(Resume theResume, EditResumeViewModel model)
        {
            List<long> eduBkgIds = uow.educationBackgroundRepository.Find(e => e.Resume.ID == theResume.ID).AsQueryable().Select(e => e.ID).ToList();
            theResume.EducationBackgrounds.Clear();

            foreach (long id in eduBkgIds)
            {
                uow.educationBackgroundRepository.Remove(uow.educationBackgroundRepository.Get(id));
            }

            AddEduBackgroundsFromViewModel(theResume, model);
        }

        private void AddOrUpdateLanguages(Resume theResume, EditResumeViewModel model)
        {
            if (theResume.Languages.Any())
            {
                /*
                List<long> langIds = uow.languageRepository.Find(e => e.ResumeId == theResume.ID).AsQueryable().Select(e => e.ID).ToList();
                theResume.Languages.Clear();

                foreach (long id in langIds)
                {
                    uow.languageRepository.Remove(uow.languageRepository.Get(id));
                }
                */
                uow.languageRepository.RemoveRange(theResume.Languages);
            }
            AddLanguagesFromViewModel(theResume, model);
        }

        private void AddLanguagesFromViewModel(Resume theResume, EditResumeViewModel model)
        {
            if (model.Languages != null)
            {
                uow.languageRepository.AddRange(model.Languages);
                theResume.Languages = model.Languages;
            }
        }

    }
}
