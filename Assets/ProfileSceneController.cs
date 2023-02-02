using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSceneController : MonoBehaviour
{
    public Text profileName;

    public Text coinsCount;

    public BadgesController badgesController;

    void Start(){
        profileName.text = UserProfileBackend.GetProfileName();
        coinsCount.text = "x"+Backend.GetCoins().ToString();

        badgesController.CheckBadgesAvailability();
    }
}
