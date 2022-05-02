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
