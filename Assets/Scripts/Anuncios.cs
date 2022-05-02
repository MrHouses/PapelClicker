using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Anuncios : MonoBehaviour
{
    RewardBasedVideoAd ad;
    private BannerView _bannerView;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       // string adUnitId = "ca-app-pub-3940256099942544/5224354917";//"ca-app-pub-4609727598306757/8106350144";
       // _bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Center);

        //AdRequest request = new AdRequest.Builder().AddTestDevice("C5FFE9677FA0E0EBAA6D10D89F35E1A1").Build();
        //_bannerView.LoadAd(request);            
        
       
        MobileAds.Initialize(appUnitId);
        this.ad = RewardBasedVideoAd.Instance;
        this.RewardAd();
    }

    private void OnDisable()
    {
        _bannerView.Destroy();
    }

    // Update is called once per frame
    void RewardAd()
    {
        ad = RewardBasedVideoAd.Instance;
        
        
        ad.LoadAd(request,adId);

        if(ad.IsLoaded())
        {
            ad.Show();
        }
    }

}
