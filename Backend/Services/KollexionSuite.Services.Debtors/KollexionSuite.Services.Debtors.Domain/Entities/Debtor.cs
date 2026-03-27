namespace KollexionSuite.Services.Debtors.Domain.Entities
{
    public class Debtor
    {
        public Guid DebtorId { get; set; }
        public string Title { get; set; } = string.Empty;              // Mr/Ms/Dr etc.
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string KycStatus { get; set; } = "Unknown";            // e.g. Unknown, Pending, Verified, Rejected
        public string Gender { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string PhysicalAddressStreet { get; set; } = string.Empty;
        public string PhysicalAddressSuburb { get; set; } = string.Empty;
        public string PhysicalAddressTown { get; set; } = string.Empty;
        public string PhysicalAddressCode { get; set; } = string.Empty;
        public string PhysicalAddressCountry { get; set; } = string.Empty;
        public string PostalAddressStreet { get; set; } = string.Empty;
        public string PostalAddressSuburb { get; set; } = string.Empty;
        public string PostalAddressTown { get; set; } = string.Empty;
        public string PostalAddressCode { get; set; } = string.Empty;
        public string Employeer { get; set; } = string.Empty;
        public string EmployeerAddressStreet { get; set; } = string.Empty;
        public string EmployeerAddressSuburb { get; set; } = string.Empty;
        public string EmployeerAddressTown { get; set; } = string.Empty;
        public string EmployeerAddressCode { get; set; } = string.Empty;
        public string EmployeerAddressCountry { get; set; } = string.Empty;
        public string EmployeerSiteName { get; set; } = string.Empty;
        public string EmployeerTelephone { get; set; } = string.Empty;
        public string EmployeerEmail { get; set; } = string.Empty;
        public string EmploymentJobTitle { get; set; } = string.Empty;
        public string EmploymentNumber { get; set; } = string.Empty;
        public string EmploymentDepartmet { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Consent> Consents { get; set; } = new List<Consent>();
        public Identifier Identifier { get; set; } = new();

    }
}
