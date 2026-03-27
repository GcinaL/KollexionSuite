namespace KollexionSuite.Services.Shared.Utilities
{

    // Base marker interface
    public interface IEvent { }

    // ----------------------------
    // Account Events
    // ----------------------------
    public enum DebtorEvent
    {
        DebtorCreated,
        DebtorUpdated,
        DebtorFlagged,
        DebtorUnflagged
    }

    // ----------------------------
    // Account Events
    // ----------------------------
    public enum AccountEvent
    {
        AccountCreated,
        AccountUpdated,
        AccountClosed,
        AccountAssignedToCollector,
        AccountReassigned,
        AccountFlagged,
        AccountUnflagged
    }

    // ----------------------------
    // Case Events
    // ----------------------------
    public enum CaseEvent
    {
        CaseCreated,
        CaseUpdated,
        CaseClosed,
        CaseReopened,
        CaseEscalated,
        CaseDeEscalated
    }

    // ----------------------------
    // Payment Events
    // ----------------------------
    public enum PaymentEvent
    {
        PaymentReceived,
        PaymentAllocated,
        PaymentFailed,
        PaymentReversed,
        PaymentDisputed,
        PaymentPromiseMade,
        PaymentPromiseBroken
    }

    // ----------------------------
    // Communication Events
    // ----------------------------
    public enum CommunicationEvent
    {
        CommunicationSent,
        CommunicationFailed,
        CommunicationOpened,
        CommunicationResponded,
        CallInitiated,
        CallCompleted,
        CallFailed
    }

    // ----------------------------
    // Workflow / Strategy Events
    // ----------------------------
    public enum WorkflowEvent
    {
        WorkflowStarted,
        WorkflowStepCompleted,
        WorkflowStepFailed,
        StrategyApplied,
        RuleEvaluated
    }

    // ----------------------------
    // Fees & Interest Events
    // ----------------------------
    public enum FinanceEvent
    {
        FeeApplied,
        FeeWaived,
        InterestAccrued,
        InterestAdjusted
    }

    // ----------------------------
    // Compliance & Legal Events
    // ----------------------------
    public enum ComplianceEvent
    {
        KycCheckCompleted,
        CreditCheckCompleted,
        BlacklistCheckCompleted,
        LegalActionInitiated,
        LegalActionClosed,
        CourtOrderReceived,
        JudgmentIssued
    }

    // ----------------------------
    // Placement & Agency Events
    // ----------------------------
    public enum PlacementEvent
    {
        PlacementCreated,
        PlacementUpdated,
        PlacementClosed,
        AgencyAssigned,
        AgencyUnassigned,
        AgencyReportReceived
    }

    // ----------------------------
    // System / Admin Events
    // ----------------------------
    public enum SystemEvent
    {
        UserCreated,
        UserDeactivated,
        CollectorPerformanceUpdated,
        SystemErrorOccurred,
        AuditLogCreated,
        Default,
    }
}
