using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public Text currentScore;

    public Text maxScore;

    public UserProfileController userProfile;

    public AudioCarEffects audioCarEffects;

    public static bool died=false;

    void Start(){
        died=false;
        gameOverPanel.SetActive(false);
    }

    public void GameOver(int score){
        userProfile.ShowCoinsAmount();
        Backend.SaveLevelProgress(score, Application.loadedLevel, 0);

        currentScore.text = score.ToString()+"%";
        int maxScoreValue = Backend.GetLevelHighestScore(Application.loadedLevel);

        maxScore.text = maxScoreValue.ToString()+"%";

        gameOverPanel.SetActive(true);

        audioCarEffects.PlayLose();

        died=true;
    }
}
