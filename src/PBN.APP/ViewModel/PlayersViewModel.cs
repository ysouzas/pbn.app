using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using PBN.APP.Services;
using PBN.APP.ViewModel.Base;
using PBN.Models;

namespace PBN.APP.ViewModel;

public partial class PlayersViewModel : BaseViewModel
{
    PlayerService playerService { get; set; }

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

    public PlayersViewModel(PlayerService playerService)
    {
        Title = "Players";

        this.playerService = playerService;

        SelectedPlayers = new ObservableCollection<object>();
    }

    [RelayCommand]
    async Task GetPlayers()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var players = await playerService.GetAll();

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
            var teams = await playerService.GenerateTeams(ids);

            var teamsToPrint = "";


            for (int i = 0; i < teams.Length; i++)
            {
                var team = teams[i];
                teamsToPrint += $"Time {i + 1} -Score: {team.Score:0.00}\n";

                foreach (var player in team.Players)
                {
                    teamsToPrint += "{player.Name} - {player.Score:0.00}\n";

                }
                teamsToPrint += "-------------------------------------\n";
            }


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
