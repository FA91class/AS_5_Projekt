namespace Impf_App.Models
{
    public class Doctor
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return Title + " " + LastName + ", " + FirstName; } }

        public string Title { get; set; }

    }
}
