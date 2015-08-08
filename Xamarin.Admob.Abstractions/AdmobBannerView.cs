using System;
using Xamarin.Forms;

namespace Xamarin.Admob.Abstractions
{
    public class AdmobBannerView : ContentView
    {
        public string AdUnitID{ get; set; }

        public AdmobBannerView(string adUnitID)
        {
            AdUnitID = adUnitID;
        }
    }
}

