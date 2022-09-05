
namespace billing.Data
{
    public static class ApplicationConstants
    {
        public const string CurrentDateDefaultValueSql = "now() at time zone 'utc'";
        public const string EnterLogAction = "Enter {0} in {1}";
        public const string Bearer = "Bearer";
        public const int AdvisorDashboardDefaultTakeCount = 20;
        public const int AdvisorDashboardDefaultSkipCount = 0;
        public const int ForceLogoutCodeForInactiveUser = 440;
        public const int ForceLogoutCodeForRoleChangedUser = 450;
        public const string ForceLogoutInactiveUserMessage = "Your account is inactive. Please contact administrator.";
        public const string ForceLogoutDeletedUserMessage = "Your account has been deleted";
        public const string CostomerIsalreadyInuse = "This customer is already in use";
        public const string ProductIsalreadyInuse = "This product is already in use";
    }
    /// <summary>
    /// Request headers
    /// </summary>
    public static class Headers
    {
        public const string RefreshToken = "X-Refresh-Token";
        public const string Authorization = "Authorization";
    }
}