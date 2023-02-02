using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class IntroductionController : MonoBehaviour
{
    public InputField nameInputField;

    public GameObject introductionPanel;

    public ProfileController profileController;

    void Start(){
        if(Backend.IsFirstOpen() == 0){
            introductionPanel.gameObject.SetActive(true);
        }else{
            introductionPanel.gameObject.SetActive(false);
        }
    }

    public void SaveUserName(){
        if(Regex.IsMatch(nameInputField.text, @"^[a-zA-Z0-9_]+$")){
            UserProfileBackend.SaveUserName(nameInputField.text);
        }
        else{
            UserProfileBackend.SaveUserName("Django");
        }

        Backend.SetIsFirstOpenState(1);
        introductionPanel.gameObject.SetActive(false);
        profileController.UpdateLabels();
    }
}
