using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PBN.APP.DTO.Request;
using PBN.APP.Services.Interfaces;
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
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            Player = await _playerService.GetPlayerWithRank(Player.Id);
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
            var rank = new Rank(Score);
            var dto = new AddRankDTO { Id = Player.Id, Rank = rank };
            Player = await _playerService.AddRank(dto);
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
