using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgesController : MonoBehaviour
{
    public List<string> badges;

    public Image[] badgesImages;

    public Text[] badgesNames;

    void Start(){
        badges = BadgesGameManager.badges;
    }

    public void CheckBadgesAvailability(){
        for(int i=0; i<badges.Count; i++){
            if(BadgesBackend.CheckIfHasBadge(badges[i]) == 1){
                var color = badgesImages[i].GetComponent<Image>().color;
                color.a = 1f;
                badgesImages[i].GetComponent<Image>().color = color;
                
                color = badgesNames[i].color;
                color.a = 1f;
                badgesNames[i].color = color;
            }
            else{
                var color = badgesImages[i].GetComponent<Image>().color;
                color.a = 0.4f;
                badgesImages[i].GetComponent<Image>().color = color;
                
                color = badgesNames[i].color;
                color.a = 0.4f;
                badgesNames[i].color = color;
            }

            badgesNames[i].text = badges[i];
        }
    }
}
