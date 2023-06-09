﻿namespace PBN.APP.Constants;

public static class ConnectionStringConstants
{
    public static string BaseUrl { get; } = string.Empty;

    public static string TeamUrl { get; } = $"{BaseUrl}/teams";

    public static string PlayerUrl { get; } = $"{BaseUrl}/football_functions";

    public static string RankUrl { get; } = $"{BaseUrl}/player";

    public static string AddRankUrl { get; } = $"{BaseUrl}/rank";

    public static string AddPlayer { get; } = $"{BaseUrl}/addPlayer";

    public static string Ranking { get; } = $"{BaseUrl}/Ranking";
}
