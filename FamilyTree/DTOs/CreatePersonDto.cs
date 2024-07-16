namespace FamilyTree.DTOs
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public int? SpouseId { get; set; }
    }
}
