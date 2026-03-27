namespace KollexionSuite.Services.Debtors.Application.DTOs
{
    public class DebtorDto
    {
        public Guid DebtorId { get; set; }
        public string Title { get; set; } = string.Empty;     
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string KycStatus { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string PhysicalAddressStreet { get; set; } = string.Empty;
        public string PhysicalAddressSuburb { get; set; } = string.Empty;
        public string PhysicalAddressTown { get; set; } = string.Empty;
        public string PhysicalAddressCode { get; set; } = string.Empty;
        public string PhysicalAddressCountry { get; set; } = string.Empty;
        public string PostalAddressStreet { get; set; } = string.Empty;
        public string PostalAddressSuburb { get; set; } = string.Empty;
        public string PostalAddressTown { get; set; }   
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

        public IdentifierDto Identifier { get; set; } = new();
        public ICollection<ContactDto> Contacts { get; set; } = new List<ContactDto>();
        public ICollection<ConsentDto> Consents { get; set; } = new List<ConsentDto>();
    }

    public class CreateDebtorDto
    {
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

        public IdentifierDto Identifier { get; set; } = new();
        public ICollection<CreateContactDto> Contacts { get; set; } = new List<CreateContactDto>();
        public ICollection<CreateConsentDto> Consents { get; set; } = new List<CreateConsentDto>();
        
    }
}
