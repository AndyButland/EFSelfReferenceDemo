namespace SelfReferenceDemo
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public Employee Manager { get; set; }

        public override string ToString()
        {
            var result = $"{FirstName} {LastName}";
            if (Manager != null)
            {
                result += $" (manager: {Manager.FirstName} {Manager.LastName})";
            }

            return result;
        }
    }
}
