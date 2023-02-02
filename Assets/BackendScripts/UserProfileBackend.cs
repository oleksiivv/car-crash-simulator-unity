using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileBackend : MonoBehaviour
{
    void Start(){
    }

    public static void SaveUserName(string name){
        PlayerPrefs.SetString("profile_name", name);
    }

    public static string GetProfileName(){
        return PlayerPrefs.GetString("profile_name");
    }
}
