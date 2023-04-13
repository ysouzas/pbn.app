﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using PBN.APP.Services.Interfaces;
using PBN.APP.ViewModel.Base;
using PBN.Models;

namespace PBN.APP.ViewModel;

public partial class PlayersViewModel : BaseViewModel
{
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

    public PlayersViewModel(IPlayerService playerService)
    {
        _playerService = playerService;
        Title = "Players";
        SelectedPlayers = new ObservableCollection<object>();
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
}
