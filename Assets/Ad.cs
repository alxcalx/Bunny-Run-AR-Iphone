using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;



public class Ad : MonoBehaviour


{
    public UnityEvent OnAdClosedEvent;
    public UnityEvent OnAdFailedtoLoadEvent;
    public UnityEvent OnAdFailedtoShow;

    private RewardedAd rewardedAd;
    public static InterstitialAd interstitialAd;
    public static int WatchMax =0 ;

    // Start is called before the first frame update
    void Start()
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() => {

            RequestRewardedAd();
            RequestAndLoadInterstitialAd();
        });

    }

    
    



private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    public void RequestRewardedAd()
    {
        this.rewardedAd = new RewardedAd("ca-app-pub-6062753775528889/4241950033");

        this.rewardedAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        this.rewardedAd.OnAdFailedToLoad += (sender, args) => OnAdFailedtoLoadEvent.Invoke();
        this.rewardedAd.OnAdFailedToShow += (sender, args) => OnAdFailedtoShow.Invoke();

        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(CreateAdRequest());

        Debug.Log("Requesting");
    }

    public void RequestAndLoadInterstitialAd()
    {

#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6062753775528889/6807074630";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public static void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }

    }



    public void UserChoseToWatchAd()
    {
       

        if (rewardedAd!=null)
        {
            this.rewardedAd.Show();
            Debug.Log("Rewarded ad is present");
            
        }
        else
        {
            Debug.Log("not working");

        }
    
    }

    

    public void Test()
    {
      
        CollisionDetection.gameend = false;
        
       WatchMax++;

        
    }

   



}
