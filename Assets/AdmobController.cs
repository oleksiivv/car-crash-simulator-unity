using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdmobController : MonoBehaviour
{
#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~2264672855";
    private string intersitionalId="ca-app-pub-4962234576866611/4316121128";

    private string bannerId="ca-app-pub-4962234576866611/9568447809";
    private string unityAds = "4919218";
#else
    private string appId="ca-app-pub-4962234576866611~8839623138";
    private string intersitionalId="ca-app-pub-4962234576866611/9838415002";

    private string bannerId="ca-app-pub-4962234576866611/8648051445";
    private string unityAds = "4919219";
#endif

    public static int adsCnt = 1;
    
    void Start(){

        Advertisement.Initialize(unityAds,false);

        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
            LoadLoadInterstitialAd();
            CreateBannerView();
            if(Application.loadedLevel>0)LoadBannerAd();
        });
    }

    AdRequest AdRequestBuild(){
        return new AdRequest.Builder().Build();
    }

    public bool showIntersitionalAd(bool unityAds=false){
        adsCnt++;
        if(adsCnt % 2 != 0){
            return false;
        }

        if(!unityAds){
            return showIntersitionalGoogleAd();
        } else {
            //if (Advertisement.IsReady()) {
                Advertisement.Show("Android_Interstitial");
            //}
        }

        return false;
    }

    private InterstitialAd _interstitialAd;

    private BannerView _bannerView;
    
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }


      public bool showIntersitionalGoogleAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }

    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    }

    public void LoadBannerAd()
    {
        // create an instance of a banner view first.
        if(_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
}
