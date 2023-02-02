using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUIController : MonoBehaviour
{
    public GameObject winPanel;

    public Slider levelProgress;

    public GameObject[] stars;

    public GameObject profilePanel;

    public NewCarReceivedController newCarReceivedController;

    public UserProfileController userProfile;

    public AudioCarEffects audioCarEffects;

    void Start(){
        //Debug only
        //showWinPanel(3, 100);
    }

    public void showWinPanel(int numberOfStars, int levelProgressValue){
        Backend.SaveLevelProgress(levelProgressValue, Application.loadedLevel, 1);
        Backend.SetLevelStars(Application.loadedLevel, numberOfStars);
        winPanel.SetActive(true);

        userProfile.ShowCoinsAmount();

        StartCoroutine(ShowProgress(levelProgressValue, numberOfStars));

        audioCarEffects.PlayWin();
    }

    IEnumerator ShowStars(int numberOfStars){
        int current = 0;
        while(true){
            yield return new WaitForSeconds(0.5f);

            if(current == numberOfStars){
                break;
            }

            stars[current].SetActive(true);

            current++;
        }

        profilePanel.SetActive(true);
        newCarReceivedController.AddNewCarIfHas();
    }

    IEnumerator ShowProgress(int value, int numberOfStars){
        while(levelProgress.value<value){
            Debug.Log("Slider value:" +levelProgress.value.ToString());
            levelProgress.value+=0.5f;
            yield return new WaitForSeconds(0.0005f);
        }

        StartCoroutine(ShowStars(numberOfStars));
    }
}
