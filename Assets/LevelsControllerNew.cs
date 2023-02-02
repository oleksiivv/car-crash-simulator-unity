using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsControllerNew : MonoBehaviour
{
    public GameObject[] levels;

    public GameObject[] padlocks;

    void Awake(){
        foreach(var padlock in padlocks)padlock.SetActive(true);
    }

    public int GetLastLevel(){
        int i=1;
        for(i=1; i<levels.Length; i++){
            padlocks[i-1].SetActive(false);
            if(PlayerPrefs.GetInt("level#"+i.ToString(), 0)!=1){
                break;
            }
        }

        return i;
    }
}
