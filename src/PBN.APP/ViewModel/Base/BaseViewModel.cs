
using CommunityToolkit.Mvvm.ComponentModel;

namespace PBN.APP.ViewModel.Base;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    bool isLoading;

    [ObservableProperty]
    string title;


    public bool IsNotLoading => !isLoading;

    public BaseViewModel()
    {

    }
}
