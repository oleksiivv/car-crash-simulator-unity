using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    public Text profileName;

    public GameObject welcomeLabel;

    public void UpdateLabels(){
        if(Backend.IsFirstOpen() == 1){
            welcomeLabel.SetActive(true);
            Backend.SetIsFirstOpenState(2);
        }else{
            welcomeLabel.SetActive(false);
        }

        if(Backend.IsFirstOpen() != 0){
            profileName.text = UserProfileBackend.GetProfileName();
        }
    }

    void Start(){
        UpdateLabels();
    }
}
