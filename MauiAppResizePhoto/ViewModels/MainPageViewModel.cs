
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

//#if IOS || ANDROID || MACCATALYST
using Microsoft.Maui.Graphics.Platform;
//#elif WINDOWS
//using Microsoft.Maui.Graphics.Win2D;
//#endif
using IImage = Microsoft.Maui.Graphics.IImage;


namespace MauiAppResizePhoto.ViewModels
{
    public partial class MainPageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private ImageSource fullImageSource;

        [ObservableProperty]
        private byte[] fullImage;

        [ObservableProperty]
        private byte[] smallImage;

        [ObservableProperty]
        private string imageSourceFileLenght;
        [ObservableProperty]
        private string imageResizeFileLenght;

        [RelayCommand]
        public async Task ClearPhoto()
        {
            IsBusy = true;
            await Task.Delay(10);

            FullImage = null; // new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            SmallImage = null;  // new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            
            IsBusy = false; 
        }


        [RelayCommand]
        public async Task CapturePhoto()
        {

            await ClearPhoto();

            IsBusy = true;
            await Task.Delay(10);

            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync(); //CapturePhotoAsync();
                
                await Task.Delay(20);
                if (photo != null)
                {

                    // save the file into local storage
                    //string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    //string localFilePath2 = Path.Combine(FileSystem.CacheDirectory, "Resize" + photo.FileName );

                    //using Stream sourceStream = await photo.OpenReadAsync();

                    //using FileStream localFileStream = File.OpenWrite(localFilePath);

                    //using Stream sourceStream =  photo.OpenReadAsync().Result;  

                    IImage image;
                    IImage image2;
                  

                    image = PlatformImage.FromStream(photo.OpenReadAsync().Result);
                  
                   // Zobrazení originální velké fotky trvá dlouho
                   // FullImage = image.AsBytes();
                   // ImageSourceFileLenght = string.Format("{0}x{1} {2} Kb", image.Width, image.Height, FullImage.GetLength(0) / 1024);
                   // await Task.Delay(10);

                    image2 = image.Downsize(1280, false); 
                    SmallImage = image2.AsBytes();
                    ImageResizeFileLenght = string.Format("{0}x{1} {2} Kb", image2.Width, image2.Height, SmallImage.GetLength(0) / 1024);


                    image.Dispose();
                    image2.Dispose();
                    photo = null;
                   
                }
            }
            IsBusy = false; 
        }

    }
}
