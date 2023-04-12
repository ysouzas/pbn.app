using PBN.APP.ViewModel;

namespace PBN.APP.View;

public partial class MainPage : ContentPage
{
    public MainPage(PlayersViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Loaded += (s, e) =>
        {
            viewModel.GetPlayersCommand.Execute(null);
        };
    }

}