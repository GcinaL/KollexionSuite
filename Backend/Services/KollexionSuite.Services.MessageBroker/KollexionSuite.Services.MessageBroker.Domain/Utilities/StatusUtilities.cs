namespace KollexionSuite.Services.MessageBroker.Domain.Utilities
{
    public enum OutboxStatus { Pending=1, InProgress=2, Published=3, Failed=4, DeadLetter=5}

}
