namespace KollexionSuite.Services.Shared.Utilities
{
    public enum PtpStatus
    {
        PENDING,   // New promise to pay
        OVERDUE,   // Within grace period
        KEPT,      // Fully honored
        BROKEN,    // Defaulted
        CANCELLED, // Voided/renegotiated
    }
}
