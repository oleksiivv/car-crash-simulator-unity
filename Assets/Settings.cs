using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MutingController
{
    public Dropdown quality;

    void Start()
    {
        if(PlayerPrefs.GetInt("quality", -1) == -1){
            PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        }

        quality.GetComponent<Dropdown>().value=PlayerPrefs.GetInt("quality");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));

        base.Start();
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality",qualityIndex);
    }


    void Update(){
        Debug.Log("Quality: " +QualitySettings.GetQualityLevel());
    }



    public GameObject undoProgressPanel;

    public void showUndoProgressPanel(){
        undoProgressPanel.SetActive(true);
    }


    public void undoProgress(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("studied",1);
        PlayerPrefs.SetInt("storyShowed",1);
        undoProgressPanel.SetActive(false);
        Start();
    }

    public void cancelUndoProgress(){
        undoProgressPanel.SetActive(false);
    }


}
