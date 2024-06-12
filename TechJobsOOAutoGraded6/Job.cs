using System;
namespace TechJobsOOAutoGraded6
{
	public class Job
	{
        

            public int Id { get; }
            private static int nextId = 1;
            public string Name { get; set; }
            public Employer EmployerName { get; set; }
            public Location EmployerLocation { get; set; }
            public PositionType JobType { get; set; }
            public CoreCompetency JobCoreCompetency { get; set; }

            // TODO: Task 3: Add the two necessary constructors.

            // Parameterless constuctor to initialize Id field
            public Job()
            {
                Id = nextId;
                nextId++;
            }

            // Constructor that takes parameters for other properties
            public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
            {
                Name = name;
                EmployerName = employerName;
                EmployerLocation = employerLocation;
                JobType = jobType;
                JobCoreCompetency = jobCoreCompetency;
            }


        // TODO: Task 3: Generate Equals() and GetHashCode() methods.  

        public override bool Equals(object? obj)
        {
            return obj is Job job &&
            Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // TODO: Task 5: Generate custom ToString() method.
        //Until you create this method, you will not be able to print a job to the console.

        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? "Data not available" : Name;
            string employer = EmployerName == null || string.IsNullOrEmpty(EmployerName.Value) ? "Data not available" : EmployerName.Value;
            string location = EmployerLocation == null || string.IsNullOrEmpty(EmployerLocation.Value) ? "Data not available" : EmployerLocation.Value;
            string type = JobType == null || string.IsNullOrEmpty(JobType.Value) ? "Data not available" : JobType.Value;
            string competency = JobCoreCompetency == null || string.IsNullOrEmpty(JobCoreCompetency.Value) ? "Data not available" : JobCoreCompetency.Value;

            return $"ID: {Id}\n"+
            $"Name: {name}\n"+
            $"Employer: {employer}\n"+
            $"Location: {location}\n"+
            $"Position Type: {type}\n"+
            $"Core Competency: {competency}";
        }
    }
}

