using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace StrafinV2
{
    public partial class App : Application
    {
        //Sets App Window Size
        const int WindowWidth = 1000;
        const int WindowHeight = 600;

        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            });

            MainPage = new MainPage();
        }
    }
}