
namespace FamilyTree.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfDeath { get; set; }

        // Parent relationships
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }

        // Spouse relationship
        public int? SpouseId { get; set; }

        // Navigation properties
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public Person Spouse { get; set; }
    }

}
