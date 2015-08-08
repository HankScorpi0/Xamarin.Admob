using Xamarin.Admob.iOS;
using Xamarin.Admob.Abstractions;
using GoogleAdMobAds;
using MonoTouch.UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobInterstitial))]

namespace Xamarin.Admob.iOS
{
    public class AdmobInterstitial : IAdmobInterstitial
    {
        GADInterstitial _adInterstitial;

        public void Show(string adUnit)
        {
            _adInterstitial = new GADInterstitial(adUnit);
            var request = GADRequest.Request;
            _adInterstitial.AdReceived += (sender, args) =>
            {
                if (_adInterstitial.IsReady)
                {                     
                    var window = UIApplication.SharedApplication.KeyWindow;
                    var vc = window.RootViewController;
                    while (vc.PresentedViewController != null)
                    {
                        vc = vc.PresentedViewController;
                    }
                    _adInterstitial.PresentFromRootViewController(vc);
                }
            };
            _adInterstitial.LoadRequest(request);

        }
    }
}

