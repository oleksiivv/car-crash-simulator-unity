using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

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
        MobileAds.Initialize(initStatus => { });

        RequestConfigurationAd();

        //RequestBannerAd();
    }

    AdRequest AdRequestBuild(){
        return new AdRequest.Builder().Build();
    }


    void RequestConfigurationAd(){
        intersitional=new InterstitialAd(intersitionalId);
        AdRequest request=AdRequestBuild();
        intersitional.LoadAd(request);

        intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
        intersitional.OnAdOpening+=this.HandleOnAdOpening;
        intersitional.OnAdClosed+=this.HandleOnAdClosed;

    }


    public bool showIntersitionalAd(bool unityAds=false){
        adsCnt++;
        if(adsCnt % 2 != 0){
            return false;
        }

        if(intersitional.IsLoaded() && !unityAds){
            intersitional.Show();
            return true;
        } else {
            if (Advertisement.IsReady()) {
                Advertisement.Show("Android_Interstitial");
            }
        }

        return false;
    }

    private void OnDestroy(){
        DestroyIntersitional();

        intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
        intersitional.OnAdOpening-=this.HandleOnAdOpening;
        intersitional.OnAdClosed-=this.HandleOnAdClosed;

    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
        intersitional.OnAdOpening-=this.HandleOnAdOpening;
        intersitional.OnAdClosed-=this.HandleOnAdClosed;

        RequestConfigurationAd();

        
    }

    private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

    public void DestroyIntersitional(){
        intersitional.Destroy();
    }




    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.TopLeft);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }
    
}
