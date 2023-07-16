

using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppResizePhoto.Models
{
    public partial class Photo: ModelBase
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private DateTime? create;

        [ObservableProperty]
        private byte[] smallImage;

        [ObservableProperty]
        private int fileLenghtKb;

    }
}
