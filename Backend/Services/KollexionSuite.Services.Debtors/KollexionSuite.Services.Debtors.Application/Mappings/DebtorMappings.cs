using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Application.Mappings;
using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Application.Mappings
{
    public static class DebtorMappings
    {
        public static DebtorDto MapToDto(Debtor debtor)
        {
            return new DebtorDto
            {
                DebtorId = debtor.DebtorId,
                Title = debtor.Title,
                FirstName = debtor.FirstName,
                MiddleName = debtor.MiddleName,
                Surname = debtor.Surname,
                DateOfBirth = debtor.DateOfBirth,
                NationalId = debtor.NationalId,
                PassportNumber = debtor.PassportNumber,
                KycStatus = debtor.KycStatus,
                Gender = debtor.Gender,
                Nationality = debtor.Nationality,
                PhysicalAddressStreet = debtor.PhysicalAddressStreet,
                PhysicalAddressSuburb = debtor.PhysicalAddressSuburb,
                PhysicalAddressTown = debtor.PhysicalAddressTown,
                PhysicalAddressCode = debtor.PhysicalAddressCode,
                PhysicalAddressCountry = debtor.PhysicalAddressCountry,
                PostalAddressStreet = debtor.PostalAddressStreet,
                PostalAddressSuburb = debtor.PostalAddressSuburb,
                PostalAddressTown = debtor.PostalAddressTown,
                PostalAddressCode = debtor.PostalAddressCode,
                Employeer = debtor.Employeer,
                EmployeerAddressStreet = debtor.EmployeerAddressStreet,
                EmployeerAddressSuburb = debtor.EmployeerAddressSuburb,
                EmployeerAddressTown = debtor.EmployeerAddressTown,
                EmployeerAddressCode = debtor.EmployeerAddressCode,
                EmployeerAddressCountry = debtor.EmployeerAddressCountry,
                EmployeerSiteName = debtor.EmployeerSiteName,
                EmployeerTelephone = debtor.EmployeerTelephone,
                EmployeerEmail = debtor.EmployeerEmail,
                EmploymentJobTitle = debtor.EmploymentJobTitle,
                EmploymentNumber = debtor.EmploymentNumber,
                EmploymentDepartmet = debtor.EmploymentDepartmet,
                Contacts = debtor.Contacts.Select(c => ContactMappings.MapToDto(c)).ToList(),
                Consents = debtor.Consents.Select(s => ConsentMappings.MapToDto(s)).ToList(),
                Identifier = new IdentifierDto
                {
                    IdentifierType = debtor.Identifier.IdentifierType,
                    IdentifierValue = debtor.Identifier.IdentifierValue
                }
            };
        }

        public static Debtor MapToEntity(CreateDebtorDto dto)
        {

            var debtor = new Debtor
            {
                DebtorId = Guid.NewGuid(),
                Title = dto.Title,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Surname = dto.Surname,
                DateOfBirth = dto.DateOfBirth,
                NationalId = dto.NationalId,
                PassportNumber = dto.PassportNumber,
                KycStatus = dto.KycStatus,
                Gender = dto.Gender,
                Nationality = dto.Nationality,
                PhysicalAddressStreet = dto.PhysicalAddressStreet,
                PhysicalAddressSuburb = dto.PhysicalAddressSuburb,
                PhysicalAddressTown = dto.PhysicalAddressTown,
                PhysicalAddressCode = dto.PhysicalAddressCode,
                PhysicalAddressCountry = dto.PhysicalAddressCountry,
                PostalAddressStreet = dto.PostalAddressStreet,
                PostalAddressSuburb = dto.PostalAddressSuburb,
                PostalAddressTown = dto.PostalAddressTown,
                PostalAddressCode = dto.PostalAddressCode,
                Employeer = dto.Employeer,
                EmployeerAddressStreet = dto.EmployeerAddressStreet,
                EmployeerAddressSuburb = dto.EmployeerAddressSuburb,
                EmployeerAddressTown = dto.EmployeerAddressTown,
                EmployeerAddressCode = dto.EmployeerAddressCode,
                EmployeerAddressCountry = dto.EmployeerAddressCountry,
                EmployeerSiteName = dto.EmployeerSiteName,
                EmployeerTelephone = dto.EmployeerTelephone,
                EmployeerEmail = dto.EmployeerEmail,
                EmploymentJobTitle = dto.EmploymentJobTitle,
                EmploymentNumber = dto.EmploymentNumber,
                EmploymentDepartmet = dto.EmploymentDepartmet,
                CreatedAt = DateTime.Now,
            };

            debtor.Contacts = dto.Contacts.Select(c => ContactMappings.MapToEntity(c, debtor.DebtorId)).ToList();
            debtor.Consents = dto.Consents.Select(s => ConsentMappings.MapToEntity(s, debtor.DebtorId)).ToList();
            debtor.Identifier = new Identifier
            {
                IdentifierId = Guid.NewGuid(),
                DebtorId = debtor.DebtorId,
                IdentifierType = dto.Identifier.IdentifierType,
                IdentifierValue = dto.Identifier.IdentifierValue,
                CreatedAt = DateTime.Now
            };

            return debtor;
        }
    }
}
