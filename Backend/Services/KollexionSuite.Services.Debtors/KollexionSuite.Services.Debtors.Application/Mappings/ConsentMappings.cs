using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Domain.Entities;

namespace KollexionSuite.Services.Debtors.Application.Mappings
{
    public static class ConsentMappings
    {
        public static Consent MapToEntity(CreateConsentDto dto, Guid debtorId)
        {
            return new Consent
            {
                ConsentId = Guid.NewGuid(),
                DebtorId = debtorId,
                Channel = dto.Channel,
                Purpose = dto.Purpose,
                IsGranted = dto.IsGranted,
                Source = dto.Source,
                GivenAt = dto.GivenAt == default ? DateTime.Now : dto.GivenAt,
                ExpiryAt = dto.ExpiryAt,
                
            };
        }
        public static void MapToEntity(Consent consent, UpdateConsentDto dto)
        {
            consent.ExpiryAt = dto.ExpiryAt;
        }

        public static ConsentDto MapToDto(Consent consent)
        {
            return new ConsentDto
            {
                ConsentId = consent.ConsentId,
                Channel = consent.Channel,
                Purpose = consent.Purpose,
                IsGranted = consent.IsGranted,
                GivenAt = consent.GivenAt,
                ExpiryAt = consent.ExpiryAt,
                Source = consent.Source
            };
        }

    }
}
