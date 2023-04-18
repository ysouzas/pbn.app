using PBN.APP.ViewModel;

namespace PBN.APP.View;


public partial class PlayerPage : ContentPage
{
    public PlayerPage(PlayerViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Loaded += (s, e) =>
        {
            viewModel.GetRanksCommand.Execute(null);
        };
    }
}