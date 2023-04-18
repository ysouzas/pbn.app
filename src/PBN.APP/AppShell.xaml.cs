using PBN.APP.View;

namespace PBN.APP;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
    }
}