using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PBN.APP.DTO.Request;
using PBN.APP.Services.Interfaces;
using PBN.APP.View;
using PBN.APP.ViewModel.Base;
using PBN.Models;

namespace PBN.APP.ViewModel;

[QueryProperty("Player", "Player")]
public partial class PlayerViewModel : BaseViewModel
{
    private readonly IPlayerService _playerService;

    [ObservableProperty]
    Player player;

    [ObservableProperty]
    decimal score;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    bool isVisible = true;

    public PlayerViewModel()
    {
    }

    public PlayerViewModel(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [RelayCommand]
    private async Task GetRanks()
    {
        if (Player is null)
        {
            return;
        }

        IsVisible = false;

        if (IsLoading) return;

        try
        {
            IsLoading = true;
            Player = await _playerService.GetPlayerWithRank(Player.Id);
            Score = 0;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", $"Unable to get players: {ex.Message}", "OK");
        }
        finally
        {
            IsLoading = false;
        }

    }

    [RelayCommand]
    private async Task SendScore()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            if (Player is not null)
            {
                var rank = new Rank(Score);
                var dto = new AddRankDTO { Id = Player.Id, Rank = rank };
                Player = await _playerService.AddRank(dto);
                Score = 0;
            }
            else
            {
                var dto = new AddPlayerDTO { Name = Name, Score = Score };

                var player = await _playerService.AddPlayer(dto);

                Dictionary<string, object> parameters = new() { { "Player", player } };

                await Shell.Current.GoToAsync($"{nameof(PlayerPage)}", true, parameters);

                Name = "";
                Score = 0;
            }


        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", $"Unable to get players: {ex.Message}", "OK");
        }
        finally
        {
            IsLoading = false;
        }

    }



}
