using DebtCollection.Services.Auditing.Entities;
using KollexionSuite.Services.Auditing.Application.DTOs;
using KollexionSuite.Services.Shared.Audit.Models;
using System.Text.Json;

namespace KollexionSuite.Services.Auditing.Application.Mappings
{
    public static class Mapper
    {
        public static AuditDto MapToDto(AuditEvent entity)
        {
            return new AuditDto
            {
                EventId = entity.EventId,
                Actor = entity.Actor,
                Action = entity.Action,
                EntityType = entity.EntityType,
                EntityId = entity.EntityId,
                At = entity.At,
                Before = entity.Before,
                After = entity.After
            };
        }

        public static AuditEvent MapToEntity(CreateAuditDto dto)
        {
            return new AuditEvent
            {
                EventId = Guid.NewGuid(),
                Actor = dto.Actor,
                Action = dto.Action.ToString(),
                EntityType = dto.EntityName,
                EntityId = dto.EntityId,
                At = DateTime.Now,
                Before = dto.Before != null ? JsonSerializer.Serialize(dto.Before) : null,
                After = dto.After != null ? JsonSerializer.Serialize(dto.After) : null,
            };
        }
    }
}
