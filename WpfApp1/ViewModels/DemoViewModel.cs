using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels;

public partial class DemoViewModel : ObservableObject
{
    [ObservableProperty] private Dock dock;
}