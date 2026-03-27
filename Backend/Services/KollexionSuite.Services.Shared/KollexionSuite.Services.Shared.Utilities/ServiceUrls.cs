namespace KollexionSuite.Services.Shared.Utilities
{
    public static class ServiceUrls
    {
        // Kafka
        public const string KafkaBootstrapServers = "localhost:9092";

        // Workflow Orchestrator
        public const string WorkflowOrchestratorUrl = "http://localhost:5000";
        public const string PaymentsApi = "http://localhost:5001";
        public const string AccountsApi = "http://localhost:5002";
        public const string NotificationsApi = "http://localhost:5003";
    }
}
