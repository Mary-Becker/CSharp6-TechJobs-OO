
using System.ComponentModel.DataAnnotations;

namespace TechJobs.Tests
{
    [TestClass]
    public class JobTests
    {
        Job job1;
        Job job2;
        Job job3;
        Job job4;

        [TestInitialize]
        public void CreateJobObjects()
        {
            // Initialize the testing objects correctly
            job1 = new Job();
            job2 = new Job();
            job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            // Ensure that job1 and job2 have unique IDs
            Assert.IsTrue(job1.Id != job2.Id, "IDs of job1 and job2 should be different");

            // Ensure that job2's ID is exactly 1 greater than job1's ID
            Assert.AreEqual(job1.Id + 1, job2.Id, "job2's ID should be exactly 1 greater than job1's ID");
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", job3.Name, "Name property not set correctly.");
            Assert.AreEqual("ACME", job3.EmployerName.Value, "EmployerName property not set correctly.");
            Assert.AreEqual("Desert", job3.EmployerLocation.Value, "EmployerLocation property not set correctly.");
            Assert.AreEqual("Quality control", job3.JobType.Value, "JobType property not set correctly.");
            Assert.AreEqual("Persistence", job3.JobCoreCompetency.Value, "JobCoreCompetency property not set correctly.");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4), "job3 and job4 are not equal due to different Id's");
        }

        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            string jobString = job3.ToString();
            Assert.IsTrue(jobString.StartsWith("\n"), "ToString() starts with a new line.");
            Assert.IsTrue(jobString.EndsWith("\n"), "ToString() ends with a new line.");
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
        string jobString = job3.ToString();
        string expectedString = $"\nID: {job3.Id}\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n";
        Assert.AreEqual(expectedString, jobString);
        }


        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            Job jobWithEmptyField = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string jobString = jobWithEmptyField.ToString();
            string expectedString = $"\nID: {jobWithEmptyField.Id}\nName: Data not available\nEmployer: Data not available\nLocation: Data not available\nPosition Type: Data not available\nCore Competency: Data not available\n";
            Assert.AreEqual(expectedString, jobString);
        }
    }
}

