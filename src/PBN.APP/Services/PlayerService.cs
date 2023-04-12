using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using PBN.Models;

namespace PBN.APP.Services;

public class PlayerService
{
    List<Player> _players = new();
    HttpClient _httpClient;
    string _url;
    public PlayerService()
    {
        _httpClient = new HttpClient();
        _url = string.Empty;
    }

    public async Task<List<Player>> GetAll()
    {
        if (_players.Count > 0)
        {
            return _players;
        }

        var url = $"{_url}/football_functions";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            _players = await response.Content.ReadFromJsonAsync<List<Player>>();
        }

        return _players;
    }

    public async Task<Team[]> GenerateTeams(List<string> ids)
    {
        var myContent = JsonSerializer.Serialize(ids);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var url = $"{_url}/teams";

        var response = await _httpClient.PostAsync(url, byteContent);
        Team[] teams = null;

        if (response.IsSuccessStatusCode)
        {
            teams = await response.Content.ReadFromJsonAsync<Team[]>();
        }

        return teams;
    }
}
