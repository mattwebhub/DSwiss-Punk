using CommunityToolkit.Mvvm.ComponentModel;

namespace DSwiss_Punk.Core.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    
    bool _isBusy;

    [ObservableProperty]
    string _title;

    public bool IsNotBusy => !IsBusy;
}