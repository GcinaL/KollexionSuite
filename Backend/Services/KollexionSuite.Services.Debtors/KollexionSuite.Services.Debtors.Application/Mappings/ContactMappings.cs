using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Application.Mappings
{
    public static class ContactMappings
    {
        public static ContactDto MapToDto(Contact entity)
        {
            return new ContactDto
            {
                ContactId = entity.ContactId,
                Type = entity.Type,
                Value = entity.Value,
                IsPrimary = entity.IsPrimary,
                IsValid = entity.IsValid,
                CreatedAt = entity.CreatedAt,
                VerifiedAt = entity.VerifiedAt
            };
        }

        public static Contact MapToEntity(CreateContactDto dto, Guid debtorId)
        {
            return new Contact
            {
                ContactId = Guid.NewGuid(),
                DebtorId = debtorId,
                Type = dto.Type,
                Value = dto.Value,
                IsPrimary = dto.IsPrimary,
                CreatedAt = DateTime.Now,
                IsValid = dto.IsValid,
            };
        }
        public static void MapToEntity(Contact contact, UpdateContactDto dto)
        {
            contact.IsPrimary = dto.IsPrimary;
            contact.IsValid = dto.IsValid;
            contact.VerifiedAt = DateTime.Now;
        }
    }
}
