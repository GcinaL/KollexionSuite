using DebtCollection.Services.Auditing.Entities;
using DebtCollection.Services.Auditing.IRepositories;
using KollexionSuite.Services.Auditing.Application.DTOs;
using KollexionSuite.Services.Auditing.Application.Interfaces;
using KollexionSuite.Services.Auditing.Application.Mappings;
using KollexionSuite.Services.Shared.Audit.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace KollexionSuite.Services.Auditing.Application.Services
{
    internal class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;

        public AuditService(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        } 
        
        public async Task<IEnumerable<AuditDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var results = await  _auditRepository.GetAllAsync(cancellationToken);
            return results.Select(Mapper.MapToDto);
        }

        public async Task<AuditDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _auditRepository.GetByIdAsync(id, cancellationToken);

            if(result == null) throw new KeyNotFoundException($"Audit event with ID {id} not found.");

            return Mapper.MapToDto(result);

        }

        public async Task<AuditDto> AddAsync(CreateAuditDto dto, CancellationToken cancellationToken)
        {
            var audit = Mapper.MapToEntity(dto);

            await _auditRepository.AddAsync(audit, cancellationToken);

            return Mapper.MapToDto(audit);
        }
    }
}
