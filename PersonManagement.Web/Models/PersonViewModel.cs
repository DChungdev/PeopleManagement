namespace PersonManagement.Web.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }       
        public string Role { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
