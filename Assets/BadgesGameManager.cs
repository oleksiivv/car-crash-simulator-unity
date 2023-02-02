using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgesGameManager : MonoBehaviour
{
    public List<Sprite> badgesBackgrounds;

    public Text title;

    public Image badge;

    public GameObject panel;

    public static List<string> badges = new List<string>{
        "Master-newbie", 
        "From first try",
        "Joker",
    };

    public void ReceiveBadge(string token){
        if(BadgesBackend.CheckIfHasBadge(token) == 1 || GameOverUIController.died){
            return;
        }

        BadgesBackend.ReceiveBadge(token);

        panel.SetActive(true);
        title.text = token;
        badge.GetComponent<Image>().sprite = badgesBackgrounds[badges.IndexOf(token)];

        Invoke(nameof(HideBadgesPanel), 2f);
    }

    private void HideBadgesPanel(){
        panel.GetComponent<Animator>().SetBool("hide", true);

        Invoke(nameof(SetBadgespanelNonActive), 1f);
    }

    void SetBadgespanelNonActive(){
        panel.SetActive(false);
    }
}
