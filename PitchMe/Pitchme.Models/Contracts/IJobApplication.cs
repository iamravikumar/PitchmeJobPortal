using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;

namespace Pitchme.Models.Contracts
{
    public interface IJobApplication : IEntity
    {
        Job job { get; set; }
        //ICompany company { get; set; }
        string pitchLocation { get; set; }
        string cvLocation { get; set; }
        ApplicationStatus applicationStatus { get; set; }
        bool Subscribed { get; set; }
    }
}
