using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using UIKit;

namespace TodoApp.MAUI
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // Método para criar o app
        public override UIWindow? Window { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var mauiApp = MauiProgram.CreateMauiApp();
            return base.FinishedLaunching(app, options);
        }
    }
}
