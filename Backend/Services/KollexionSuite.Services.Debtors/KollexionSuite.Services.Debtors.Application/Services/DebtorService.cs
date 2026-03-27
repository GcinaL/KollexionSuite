using KollexionSuite.Services.Debtors.Application.Interfaces;
using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Application.Mappings;
using KollexionSuite.Services.Debtors.Domain.Entities;
using KollexionSuite.Services.Debtors.Domain.IRepositories;
using KollexionSuite.Services.Shared.Audit.Abstractions;
using KollexionSuite.Services.Shared.Audit.Models;
using KollexionSuite.Services.Shared.Audit.Util;
using KollexionSuite.Services.Shared.MessageBroker.Abstractions;
using System.Text.Json;
using KollexionSuite.Services.Shared.Common.Abstraction;
using KollexionSuite.Services.Shared.MessageBroker.Models;
using KollexionSuite.Services.Shared.Workflows.Models.Events;
using KollexionSuite.Services.Shared.Workflows;

namespace KollexionSuite.Services.Debtors.Application.Services
{
    public class DebtorService : IDebtorService
    {
        private readonly IDebtorRepository _debtorRepo;
        private readonly IContactRepository _contactRepo;
        private readonly IMessageBrokerClient _broker;
        private readonly IBackgroundTaskRunner _backgroundTasks;

        private const string _auditTopic = "audit.create";

        public DebtorService(IDebtorRepository debtorRepo, IContactRepository contactRepo, IAuditClient audit, IMessageBrokerClient broker, IBackgroundTaskRunner backgroundTasks)
        {
            _debtorRepo = debtorRepo;
            _contactRepo = contactRepo;
            _broker = broker;
            _backgroundTasks = backgroundTasks;
        }

        public async Task<DebtorDto> AddAsync(CreateDebtorDto debtorDto, string actor, CancellationToken ct)
        {
            var debtor = (Debtor)Mapper.MapToEntity(debtorDto);
            await _debtorRepo.AddAsync(debtor, ct);
            var dto = (DebtorDto)Mapper.MapToDto(debtor);

            _backgroundTasks.Run
             ([
                _broker.PublishAsync("debtor.created", debtor.DebtorId.ToString(), JsonSerializer.Serialize(dto)),
                _broker.PublishAsync(_auditTopic, debtor.DebtorId.ToString(), JsonSerializer.Serialize(new CreateAuditDto { Actor = actor, Action = AuditAction.CREATE, EntityName = nameof(Debtor), EntityId = debtor.DebtorId }))
              ],
                debtor.DebtorId.ToString(),
                nameof(Debtor)
              );

            return dto;
        }

        public async Task DeleteAsync(Guid id, string actor, CancellationToken cancellationToken)
        {
            if(await _debtorRepo.DeleteAsync(id, cancellationToken))
            {
                _backgroundTasks.Run
                 ([
                    _broker.PublishAsync("debtor.deleted", id.ToString(), JsonSerializer.Serialize(new { DebtorId = id })),
                    _broker.PublishAsync(_auditTopic, id.ToString(), JsonSerializer.Serialize(new CreateAuditDto { Actor = actor, Action = AuditAction.DELETE, EntityName = nameof(Debtor), EntityId = id }))
                  ],
                id.ToString(),
                nameof(Debtor)
              );
            }
        }

        public async Task<IEnumerable<DebtorDto>> GetAllAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 50)
        {
            var debtors = await _debtorRepo.GetAllAsync(cancellationToken, page, pageSize);

            return debtors.Select(d => (DebtorDto)Mapper.MapToDto(d));
        }

        public async Task<DebtorDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var debtor = await _debtorRepo.GetByIdAsync(id, cancellationToken);

            if (debtor == null) throw new KeyNotFoundException($"Debtor with id {id} not found.");

            return (DebtorDto)Mapper.MapToDto(debtor);
        }

        public async Task<DebtorDto> GetByIdentifierAsync(string type, string value, CancellationToken cancellationToken)
        {
            var debtor = await _debtorRepo.GetByIdentifierAsync(type, value, cancellationToken);

            if (debtor == null) throw new KeyNotFoundException($"Debtor with identifier {type}:{value} not found.");

            return (DebtorDto)Mapper.MapToDto(debtor);
        }

        public async Task<DebtorDto> UpdateAsync(Guid id, DebtorDto debtorDto, string actor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactDto> AddContactAsync(Guid debtorId, CreateContactDto contactDto, string actor, CancellationToken cancellationToken)
        {
            if (await _debtorRepo.GetByIdAsync(debtorId, cancellationToken) == null)
                throw new KeyNotFoundException($"Debtor with id {debtorId} not found.");

            var contact = (Contact)Mapper.MapToEntity(contactDto, debtorId);
            await _contactRepo.AddAsync(contact, cancellationToken);
            var dto = (ContactDto)Mapper.MapToDto(contact);

            _backgroundTasks.Run
                ([
                   _broker.PublishAsync("contact.created", contact.ContactId.ToString(), JsonSerializer.Serialize(dto)),
                    _broker.PublishAsync(_auditTopic, contact.ContactId.ToString(), JsonSerializer.Serialize(new CreateAuditDto { Actor = actor, Action = AuditAction.CREATE, EntityName = nameof(Contact), EntityId = contact.ContactId }))
                 ],
               contact.ContactId.ToString(),
               nameof(Contact)
             );

            return dto;
        }

        public async Task<ContactDto> UpdateContactAsync(Guid contactId, UpdateContactDto contactDto, string actor, CancellationToken cancellationToken)
        {
            var contact = await _contactRepo.GetByIdAsync(contactId, cancellationToken);

            if (contact == null) throw new KeyNotFoundException($"Contact with id {contactId} not found.");

            Mapper.MapToEntity(contact, contactDto);

            var before = (ContactDto)Mapper.MapToDto(contact);

            await _contactRepo.UpdateAsync(contact, cancellationToken);

            var after = (ContactDto)Mapper.MapToDto(contact);

            _backgroundTasks.Run
                ([
                   _broker.PublishAsync("contact.updated", contact.ContactId.ToString(), JsonSerializer.Serialize(after)),
                    _broker.PublishAsync(_auditTopic, contact.ContactId.ToString(), JsonSerializer.Serialize(new CreateAuditDto { Actor = actor, Action = AuditAction.UPDATE, EntityName = nameof(Contact), EntityId = contact.ContactId, Before = before, After = after  }))
                 ],
               contact.ContactId.ToString(),
               nameof(Contact)
             );

            return after;
        }

        public async Task<ContactDto> GetContactByIdAsync(Guid contactId, CancellationToken cancellationToken)
        {
            var contact = await _contactRepo.GetByIdAsync(contactId, cancellationToken);
            if (contact == null) throw new KeyNotFoundException($"Contact with id {contactId} not found.");
            return (ContactDto)Mapper.MapToDto(contact);
        }
    }
}
