using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Application.Mappings
{
    public static class Mapper
    {
        public static object MapToDto(object entity)
        {
            return entity switch
            {
                Debtor => DebtorMappings.MapToDto((Debtor)entity),
                Consent => ConsentMappings.MapToDto((Consent)entity),
                Contact => ContactMappings.MapToDto((Contact)entity),
                _ => throw new ArgumentException("Unknown entity type", nameof(entity))
            };

        }

        public static object MapToEntity(object createDto)
        {
            return DebtorMappings.MapToEntity((CreateDebtorDto)createDto);
        }

        public static object MapToEntity(object createDto, Guid debtorId)
        {
            return createDto switch
            {
                Consent => ConsentMappings.MapToEntity((CreateConsentDto)createDto, debtorId),
                Contact => ContactMappings.MapToEntity((CreateContactDto)createDto, debtorId),
                _ => throw new ArgumentException("Unknown entity type", nameof(createDto))
            };
        }

        public static void MapToEntity(object entity, object dto)
        {
            switch (entity)
            {
                case Consent : ConsentMappings.MapToEntity((Consent)entity, (UpdateConsentDto)dto); break;
                case Contact: ContactMappings.MapToEntity((Contact)entity, (UpdateContactDto)dto); break;
            }
        }

    }
}
