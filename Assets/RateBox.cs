using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBox : MonoBehaviour
{
    public void rate(){
      Backend.SetGameIsCompletedPanelAlreadyShowed(1);
      Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudioGames.CarsSmashTest");
      Backend.Rate();
      gameObject.SetActive(false);
    }

    public void remindLater(){
      LevelsController.ShowRateBoxCnt=2;
      gameObject.SetActive(false);
    }

    public void remindNewer(){
      Backend.Rate();
      gameObject.SetActive(false);
    }

    public void doNotRate(){
      Backend.SetGameIsCompletedPanelAlreadyShowed(1);
      Backend.Rate();
      gameObject.SetActive(false);
    }
}
