using Camera.MAUI;

namespace CameraPictureInPicture
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            cameraView.CamerasLoaded += CameraView_CamerasLoaded;
        }

        private void CameraView_CamerasLoaded(object sender, EventArgs e)
        {
            if (cameraView.NumCamerasDetected > 0)
            {
                cameraView.Camera = cameraView.Cameras.Where(x => x.Position == CameraPosition.Front).First();
                cameraView.MirroredImage = true;

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (await cameraView.StartCameraAsync() == CameraResult.Success)
                    {

                    }
                });
            }
        }

    }
}