using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchme.Models.Enums
{
    public enum JobType
    {
        FullTime,
        PartTime,
        Contract,
        Freelance
    }

    public enum RenumerationRange
    {
        BetweenHundredAndOneFifty ,
        BetweenOneFiftyAndThreeHundred,
        BetweenThreeHundredAndFiveHundred,
        AboveFiveHundred
    }

    public enum Qualification
    {
        Diploma,
        HND,
        BSC,
        Professional_Certification,
        MSC,
        Doctorate,
        Professor,
        Other
    }

    public enum ApplicationStatus
    {
        PendingSubmission, //When unable to submit application due to unsubscription
        Interested,//When a company picks interest in the job profile
        InterviewScheduled //when an applicant is called upon for an interview
    }

    public enum SubscriptionType
    {
        Single,
        Periodic
    }
    public enum ExperienceLevel
    {
        Intern,
        Trainee,
        EntryLevel,
        Junior,
        MidLevel,
        MidSeniorLevel,
        Senior,
        TopLevel
    }

    public enum Gender { Male, Female}

    public enum JobStatus
    {
        Vacant,
        Filled,
        Closed
    }
}
