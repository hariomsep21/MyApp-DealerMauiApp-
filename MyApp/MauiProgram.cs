using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyApp.Service;
using MyApp.View.Home;
using MyApp.View.Login;
using MyApp.ViewModel;
using Syncfusion.Maui.Core.Hosting;
using The49.Maui.BottomSheet;

namespace MyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                  .ConfigureSyncfusionCore()
                .UseMauiCommunityToolkit()
                .UseBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NotoSans-Medium.ttf", "AppTextFont");
                });
            builder.Services.AddSingleton<ProcurementDetailView>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<ImageViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<StockAuditView>();
            builder.Services.AddSingleton<PaymentView>();
            builder.Services.AddSingleton<ImageView1>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPage2>();
            builder.Services.AddSingleton<BasicDetailView>();
            builder.Services.AddSingleton<CarViewModel>();
          //  builder.Services.AddSingleton<BasicDetailViewModel>();
            builder.Services.AddSingleton<AuditPendingView>();
            builder.Services.AddSingleton<AuditStatusView>();
            builder.Services.AddSingleton<UnregisteredView>();
            builder.Services.AddSingleton<VerificationViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID              
handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent); 
                #elif IOS   
handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;   
handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                #endif
            });

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });

            return builder.Build();
        }
    }
}