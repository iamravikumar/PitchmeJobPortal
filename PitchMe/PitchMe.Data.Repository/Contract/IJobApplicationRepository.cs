﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;

namespace PitchMe.Data.Repository.Contract
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        List<User> GetApplicants(long jobId);
    }
}
