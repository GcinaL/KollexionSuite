namespace KollexionSuite.Services.Shared.Utilities
{
    
   

    public enum _FeeType
    {
        ADMIN,                 // General administrative fee
        COLLECTION,            // Standard collection fee
        LATE_PAYMENT,          // Fee for overdue payments
        LEGAL,                 // Legal fees for pursuing debt
        TRACING,               // Fee for locating the debtor
        DEMAND_LETTER,         // Cost of sending demand letters
        RETURN_FEE,            // Fee for bounced/returned payments
        COMMISSION,            // Agent commission fee
        SETTLEMENT,            // Fee for negotiated settlements
        CANCELLATION,          // Fee for cancelled agreements
        ENFORCEMENT,           // Fee for enforcement actions
        CARD_TRANSACTION       // Fee for processing credit/debit card payments
    }


    public enum _InterestType
    {
        CONTRACTUAL,    // Interest agreed in the original contract
        DEFAULT,        // Interest for default on payment obligations
        JUDGMENT,       // Interest applied after court judgment
        POST_JUDGMENT,  // Interest applied after judgment has been entered
        COMPOUND,       // Daily or periodic compound interest
        ARREARS,        // Interest on overdue amounts from prior periods
        STATUTORY,      // Statutory interest as per law (e.g., National Credit Act)
        ADMIN,          // Administrative interest for managing overdue accounts
        PROMOTIONAL,    // Interest for promotional or grace periods
        LEGAL           // Interest applied during pre-judgment legal proceedings
    }

    public enum _RateType
    {
        AMOUNT,
        PERCENTAGE,   
    }

    public enum _BillingPeriod
    {
        MONTHLY,
        ANNUALLY,
        ONCEOFF,
        DAILY,
        PER_EVENT,
    }

    public enum _Penalty
    {
        LATE_PAYMENT_FEE,
        DAILY_INTEREST,
        MONTHLY_INTEREST_CAP,
        MAXIMUM_LATE_FEE,
        MISSED_DEBIT_ORDER_PENALTY,
        GRACE_PERIOD_INTEREST,
        PARTIAL_PAYMENT_PENALTY,
        REINSTATEMENT_FEE,
        DEFAULT_NOTICE_FEE,
        ACCELERATED_INTEREST
    }

    public enum _PenaltyType
    {
        FIXED_FEE,
        INTEREST,
        INTEREST_CAP,
        FEE_CAP,
        PRO_RATA_FEE
    }

    public enum _PenaltyFrequency
    {
        ONCE,
        DAILY,
        MONTHLY,
        ONCE_PER_BILLING_CYCLE,
        ONCE_PER_MISSED_PAYMENT,
        PER_ACCOUNT,
        PER_FAILED_DEBIT,
        PER_NOTIFICATION,
        CUSTOM_EVENT_BASED
    }

    public enum _PenaltyTriggerCondition
    {
        PAYMENT_PAST_DUE_DATE,           // Payment was not made by the due date
        PAYMENT_OVERDUE,                 // Payment is overdue
        MULTIPLE_MISSED_PAYMENTS,        // Several payments have been missed
        DEBIT_ORDER_FAILED,               // Debit order or scheduled payment failed
        PAYMENT_OVERDUE_AFTER_GRACE_PERIOD, // Overdue payment after grace period
        PARTIAL_PAYMENT_MADE,             // Only a partial payment was made
        ACCOUNT_SUSPENDED_DUE_TO_NON_PAYMENT, // Account suspension triggered
        DEFAULT_NOTICE_SENT,              // Formal default notice sent
        ACCOUNT_IN_COLLECTION_OVER_90_DAYS // Account overdue for 90+ days
    }

}
