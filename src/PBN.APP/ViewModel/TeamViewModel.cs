using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using PBN.APP.Services;
using PBN.APP.Services.Interfaces;
using PBN.APP.ViewModel.Base;
using PBN.APP.Models;

namespace PBN.APP.ViewModel;

public partial class TeamsViewModel : BaseViewModel
{
    private readonly ITeamService _teamService;
    private readonly IPlayerService _playerService;

    public ObservableCollection<Player> Players { get; } = new();

    ObservableCollection<object> selectedPlayers;

    public ObservableCollection<object> SelectedPlayers
    {
        get
        {
            return selectedPlayers;
        }
        set
        {
            if (selectedPlayers != value)
            {
                selectedPlayers = value;
            }
        }
    }

    public TeamsViewModel(ITeamService teamService, IPlayerService playerService)
    {
        Title = "Teams";
        SelectedPlayers = new ObservableCollection<object>();
        _teamService = teamService;
        _playerService = playerService;
    }

    [RelayCommand]
    async Task GetPlayers()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var players = await _playerService.GetAll();

            if (Players.Any())
            {
                Players.Clear();
            }

            foreach (var player in players)
            {
                Players.Add(player);
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

    [RelayCommand]
    async Task GenerateTeams()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var ids = SelectedPlayers.Select(sp => ((Player)sp).Id).ToList();

            var teams = await _teamService.GenerateTeams(ids);
            var teamsToPrint = _teamService.GetTeamsAsString(teams);

            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = teamsToPrint,
                Title = "Share Text"
            });
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