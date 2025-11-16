namespace StudentsManagementSystem_Kolyo_Kolev_F113002.Models
{
    public class Subject
    {
        private string _name = string.Empty;
        private int _credits;

        // Unique identifier of the subject.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Subject name.
        public string Name
        {
            get => _name;
            set => _name = value.Trim();
        }

        // Number of credits for the subject.
        public int Credits
        {
            get => _credits;
            set => _credits = value;
        }
    }
}
