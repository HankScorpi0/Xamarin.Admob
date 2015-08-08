using Xamarin.Admob.Abstractions;
using Android.Gms.Ads;
using Xamarin.Admob.Android;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobInterstitial))]

namespace Xamarin.Admob.Android
{
    public class AdmobInterstitial : IAdmobInterstitial
    {
        InterstitialAd _ad;

        public void Show(string adUnit)
        {                        
            var context = Application.Context;
            _ad = new InterstitialAd(context);
            _ad.AdUnitId = adUnit;

            var intlistener = new InterstitialAdListener(_ad);
            intlistener.OnAdLoaded();
            _ad.AdListener = intlistener;

            var requestbuilder = new AdRequest.Builder();
            _ad.LoadAd(requestbuilder.Build());
        }
    }
}

