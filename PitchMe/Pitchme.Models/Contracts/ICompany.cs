using Pitchme.Models.Implementation;
using System.Collections.Generic;

namespace Pitchme.Models.Contracts
{
    public interface ICompany : IEntity
    {
        string Name { get; set; }
        string Location { get; set; }
        string Description { get; set; }
        string ProfileImageUri { get; set; }
        string ContactNumberOne { get; set; }
        string ContactNumberTwo { get; set; }
        IList<Job> Jobs { get; set; }
    }
}