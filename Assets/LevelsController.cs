using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    public static int ShowRateBoxCnt = 0;

    public GameObject[] levels;

    public GameObject[] padlocks;

    public Text totalStarsCountText;

    private int totalStarsCount;

    public GameObject gameIsCompletedPanel, ratePanel;

    void Awake(){
        foreach(var padlock in padlocks)padlock.SetActive(true);

        if(ShowRateBoxCnt%2 == 1){
            if(!Backend.IsRated()){
                ratePanel.SetActive(true);
            }
        }
        ShowRateBoxCnt++;
    }

    public int GetLastLevel(){
        int i=1;
        for(i=1; i<=levels.Length; i++){
            padlocks[i-1].SetActive(false);
            totalStarsCount+=Backend.GetLevelStars(i);
            if(Backend.LevelIsCompleted(i)!=1){
                break;
            }
        }

        if(gameIsCompletedPanel != null){
            if(i>=levels.Length && !Backend.GameIsCompletedPanelAlreadyShowed()){
                gameIsCompletedPanel.SetActive(true);

                Backend.SetGameIsCompletedPanelAlreadyShowed();
            }
        }

        totalStarsCountText.text = totalStarsCount.ToString()+"/"+(levels.Length*3).ToString();

        return i <= padlocks.Length ? i : padlocks.Length;
    }
}
