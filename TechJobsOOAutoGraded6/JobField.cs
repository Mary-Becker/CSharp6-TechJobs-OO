namespace TechJobsOOAutoGraded6
{
    public abstract class JobField
    {
        public int Id { get; }
        private static int nextId = 2;
        public string Value { get; set; }

        static JobField()
        {
            nextId = 2;
        }

        // Parameterless constructor to initialize Id field
        public JobField()
        {
            Id = nextId;
            Console.WriteLine($"Assigning Id {Id} to new job field, nextId was {nextId}");
            nextId++;
            Console.WriteLine($"nextId incremented to {nextId}");
        }

        // Constructor that takes value parameter
        public JobField(string value) : this()
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is JobField jobField)
            {   
                return Id == jobField.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}