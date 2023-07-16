
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiAppResizePhoto.Models
{
    public partial class PhotoCache : ModelBase
    {
        
        [ObservableProperty]
        ObservableCollection<Photo> smallPhotoColl = new();


        [RelayCommand]
        public async Task ClearAllPhoto()
        {
            await Task.Delay(10);
            SmallPhotoColl.Clear();
        }

    }
}
