#if IOS
using Foundation;
using UIKit;
#endif

namespace ImageSaveIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
#if IOS
            if (this.image != null && this.image.Handler != null && this.image.Handler.PlatformView is UIImageView uiImage)
            {
                var nativeImage = uiImage.Image;
                if (nativeImage == null)
                {
                    return;
                }

                var formattedImage = nativeImage.AsJPEG();
                if (formattedImage == null)
                {
                    return;
                }

                Stream? stream = formattedImage.AsStream();
                if (stream == null || stream == Stream.Null)
                {
                    return;
                }

                string downloadFilePath = "/Users/syncfusion/Downloads";
                string filePath = Path.GetFullPath(Path.Combine(downloadFilePath, "IosImage.jpeg"));

                NSData? imageData = NSData.FromStream(stream);
                if (imageData != null)
                {
                    imageData.Save(filePath, false, out NSError? nsError);

                }
            }
#endif
        }
    }

}
