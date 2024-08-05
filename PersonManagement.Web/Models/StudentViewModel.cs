﻿namespace PersonManagement.Web.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? AddressId { get; set; }
        public AddressViewModel Address { get; set; }

        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
    }
}
