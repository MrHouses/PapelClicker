using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Anuncios : MonoBehaviour
{
    private BannerView _bannerView;
    void Awake()
    {
        string appUnitId = "ca-app-pub-4609727598306757~3512860401";
        MobileAds.Initialize(appUnitId);
    }
    // Start is called before the first frame update
    void Start()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";//"ca-app-pub-4609727598306757/8106350144";
        _bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Center);

        AdRequest request = new AdRequest.Builder().AddTestDevice("C5FFE9677FA0E0EBAA6D10D89F35E1A1").Build();
        _bannerView.LoadAd(request);            
        
    }

    private void OnDisable()
    {
        _bannerView.Destroy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}