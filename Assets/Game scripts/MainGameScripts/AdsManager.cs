using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour , IUnityAdsListener
{
    string gameID = "4284579";
    string rewardedID = "Rewarded_Android";
    Action onRewardedContinueGameSucsses;

    public static bool isWatchedRestartAD = false;
    public static bool isWatchedCoinsAD = false;
    public static bool isWatchedAdBefore;
    public GameObject Loading;
    public Text watchAdButtonText;
    public Text watchAdButtonUnderText;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        Debug.Log("Initialzing advertisment");
    }

    public void playRewardedRestartAD(Action onWatched)
    {
        if (isWatchedAdBefore)
        {
            watchAdButtonText.text = "IT WAS ONLY ONE CHANCE";
            watchAdButtonUnderText.text = "No More";
            return;
        }
        onRewardedContinueGameSucsses = onWatched;
        if (Advertisement.IsReady(rewardedID))
        {
            Debug.Log("Ad is ready to show");
            Loading.SetActive(false);
            Advertisement.Show(rewardedID);
        }
        if (!Advertisement.IsReady(rewardedID))
        {
            Loading.SetActive(true);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("AD is ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"An error occurred while getting Ad,  Error Message: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad had started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedID && showResult == ShowResult.Finished)
        {
            Debug.Log("The player is rewarded");
            isWatchedAdBefore = true;
            onRewardedContinueGameSucsses.Invoke();
        }
        else
        {
            Debug.LogError("Something went wrong either with the code or player trying to skip!");
        }
    }
}
