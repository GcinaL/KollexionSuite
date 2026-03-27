namespace KollexionSuite.Services.Shared.Utilities
{
    public enum BusinessRuleCode
    {
        // Allocation Rules
        ALLOC_FEES_FIRST,
        ALLOC_INTEREST_FIRST,
        ALLOC_PRINCIPAL_FIRST,
        ALLOC_PROPORTIONAL,
        ALLOC_CUSTOM_SEQUENCE,

        // Penalty Rules
        PENALTY_LATE_PAYMENT,
        PENALTY_OVERDUE_BALANCE,
        PENALTY_MISSED_INSTALLMENT,
        PENALTY_EARLY_TERMINATION,
        PENALTY_ADMIN_CHARGE,

        // Interest Rules
        INTEREST_SIMPLE,
        INTEREST_COMPOUND,
        INTEREST_DAILY,
        INTEREST_MONTHLY,
        INTEREST_ANNUAL,

        // Payment Rules
        PAYMENT_DEBIT_ORDER,
        PAYMENT_EFT,
        PAYMENT_CARD,
        PAYMENT_CASH,
        PAYMENT_REVERSAL,

        // Compliance Rules
        COMPLIANCE_KYC_REQUIRED,
        COMPLIANCE_CREDIT_CHECK,
        COMPLIANCE_BLACKLISTED,
        COMPLIANCE_MAX_DEBT_RATIO,
        COMPLIANCE_AGE_LIMIT,

        // Notification Rules
        NOTIFY_PAYMENT_RECEIVED,
        NOTIFY_PAYMENT_DUE,
        NOTIFY_ACCOUNT_OVERDUE,
        NOTIFY_RULE_TRIGGERED,
        NOTIFY_CUSTOM,

        // System Rules
        SYSTEM_AUDIT_LOG,
        SYSTEM_DATA_RETENTION,
        SYSTEM_AUTO_RECONCILIATION,
        SYSTEM_SUSPEND_ACCOUNT,
        SYSTEM_ESCALATE_CASE
    }

    public enum BusinessRuleType
    {
        ALLOCATION,
        PENALTY,
        INTEREST,
        PAYMENT,
        COMPLIANCE,
        NOTIFICATION,
        SYSTEM
    }
}
