using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIController : MonoBehaviour
{
    public CarSpawnController carSpawnController;

    public Slider progressSlider;

    public bool isDebug=true;

    public GameObject nextCarButton;

    public GameObject pausePanel;

    public GameObject deathPanel;

    public GameObject profilePanel;

    public Text coinsAmount;

    public UserProfileController profile;

    public ScenesManager scenesManager;

    private AdmobController admob;

    void Start(){
        Resume();

        //Backend.SeedDataStore();
        ShowCoinsAmount();

        admob = gameObject.AddComponent<AdmobController>();
    }

    public void ShowCoinsAmount(){
        coinsAmount.text = "x" + Backend.GetCoins().ToString();
    }

    public void Pause(){
        //Time.timeScale=0;

        profilePanel.SetActive(false);
        pausePanel.SetActive(true);

        profile.ShowCoinsAmount();

        admob.showIntersitionalAd();
    }

    public void Resume(){
        //Time.timeScale=1;

        profilePanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    //debug only
    public void PlusOne(){
        carSpawnController.Spawn();
    }

    public void Restart(){
        admob.showIntersitionalAd();
        
        OpenScene(Application.loadedLevel);
    }

    public void OpenNextLevel(bool isLast){
        if(isLast){
            OpenScene(0);
            return;
        }

        OpenScene(Application.loadedLevel+1);
    }

    public void OpenScene(int scene){
        scenesManager.OpenScene(scene);
    }

    public void OpenMenu(){
        OpenScene(0);
    }

    //0...100
    public void ShowProgress(int value){
        StartCoroutine(upgradeProgress(value));
    }

    IEnumerator upgradeProgress(int value){
        while(progressSlider.value<value){
            progressSlider.value+=0.2f;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
