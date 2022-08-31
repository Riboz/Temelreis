using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class buttoncode : MonoBehaviour
{
    private InterstitialAd interstitial;
    //resources da android kısmına kendi id ni yazman lazım

private void RequestInterstitial()
{
    #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        string adUnitId = "unexpected_platform";
    #endif
    // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
}


 

private void GameOver()
{
  if (this.interstitial.IsLoaded()) {
    this.interstitial.Show();
  }
}

// buradan üstü reklam entegrasyonu kodları---------------------;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        //eklemeyi unutma
        
        RequestInterstitial();
        }


        
public IEnumerator a()
{
   
    yield return new WaitForSeconds(4f);
   
    
    SceneManager.LoadScene("level");
    yield break;
}
public void oyungir()
{
    StartCoroutine(a());
    GameOver();
    badfatboy.gamestart=false;
    Time.timeScale=1;
}
public void exit()
{
    Application.Quit();
}

}
