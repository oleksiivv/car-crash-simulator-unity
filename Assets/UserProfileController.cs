using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserProfileController : MonoBehaviour
{
    public Text profileName;

    public Text coinsAmount;

    public List<Image> slots;

    public BadgesGameManager badgesGameManager;

    public Color32 activeBadge, nonActiveBadge;

    void Start(){
        profileName.text = UserProfileBackend.GetProfileName();

        ShowCoinsAmount();
    }

    public void ShowCoinsAmount(){
        coinsAmount.text = "x"+Backend.GetCoins().ToString();

        ShowBadges();
    }

    public void ShowBadges(){
        int n=0;

        foreach(var slot in slots)slot.GetComponent<Image>().color = nonActiveBadge;

        for(int i=0; i<BadgesGameManager.badges.Count; i++){
            if(BadgesBackend.CheckIfHasBadge(BadgesGameManager.badges[i]) == 1){
                slots[n].GetComponent<Image>().color = activeBadge;
                slots[n].GetComponent<Image>().sprite = badgesGameManager.badgesBackgrounds[i];

                n++;
            }
        }
    }
}
