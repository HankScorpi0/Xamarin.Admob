using Xamarin.Forms;
using Xamarin.Admob.iOS;
using Xamarin.Forms.Platform.iOS;
using GoogleAdMobAds;
using MonoTouch.UIKit;
using Xamarin.Admob.Abstractions;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]

namespace Xamarin.Admob.iOS
{
    public class AdmobBanner : ViewRenderer
    {
        GADBannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            var adMobElement = Element as AdmobBannerView;

            if (null != adMobElement)
            {
                adView = new GADBannerView(GADAdSizeCons.Banner)
                {
                    AdUnitID = adMobElement.AdUnitID,
                    RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
                };

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen)
                        AddSubview(adView);
                    viewOnScreen = true;
                };

                adView.LoadRequest(GADRequest.Request);
                SetNativeControl(adView);
            }                
        }
    }
}
