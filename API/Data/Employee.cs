namespace API.Data
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string StringAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }  
        public string Country { get; set; }
        public virtual IList<Skill> Skills { get; set; }
    }
}
