// <copyright file="JobServiceTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PitchMe.Services.Implementation;

namespace PitchMe.Services.Implementation.Tests
{
    /// <summary>This class contains parameterized unit tests for JobService</summary>
    [PexClass(typeof(JobService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class JobServiceTest
    {
        /// <summary>Test stub for ChangeStatus(Int64, Int32)</summary>
        [PexMethod]
        
        public void ChangeStatusTest(
            [PexAssumeUnderTest]JobService target,
            long jobId,
            int status
        )
        {
            target.ChangeStatus(jobId, status);
            // TODO: add assertions to method JobServiceTest.ChangeStatusTest(JobService, Int64, Int32) 
            Assert.IsTrue(true);
        }
    }
}
