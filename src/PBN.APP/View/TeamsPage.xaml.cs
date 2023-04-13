using PBN.APP.ViewModel;

namespace PBN.APP.View;

public partial class TeamsPage : ContentPage
{
    public TeamsPage(TeamsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Loaded += (s, e) =>
        {
            viewModel.GetPlayersCommand.Execute(null);
        };
    }

}