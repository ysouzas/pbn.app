namespace PBN.APP.Constants
{
    public static class ConnectionStringConstants
    {
        public static string BaseUrl { get; } = string.Empty;

        public static string TeamUrl { get; } = $"{BaseUrl}/teams";
        public static string PlayerUrl { get; } = $"{BaseUrl}/football_functions";

    }
}
