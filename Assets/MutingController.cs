using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutingController : MonoBehaviour
{
    public GameObject buttonMutedMusic, buttonNormalMusic;

    public GameObject buttonMutedSound, buttonNormalSound;

    public GameObject audioController;

    public void Start()
    {
        if(buttonMutedSound != null)
        {
            if(PlayerPrefs.GetInt("!sound")==0){
                buttonMutedSound.SetActive(false);
                buttonNormalSound.SetActive(true);

            }
            else{
                buttonMutedSound.SetActive(true);
                buttonNormalSound.SetActive(false);
            }
        }

        
        if(buttonMutedMusic != null){
            if(PlayerPrefs.GetInt("!music")==0){
                buttonMutedMusic.SetActive(false);
                buttonNormalMusic.SetActive(true);
            }
            else{
                buttonMutedMusic.SetActive(true);
                buttonNormalMusic.SetActive(false);
            }
        }
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        buttonMutedSound.SetActive(true);
        buttonNormalSound.SetActive(false);
        //GetComponent<AudioSource>().enabled=false;
        
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        buttonMutedSound.SetActive(false);
        buttonNormalSound.SetActive(true);

        //GetComponent<AudioSource>().enabled=true;
    }


    public void muteMusic(){
        PlayerPrefs.SetInt("!music",1);
        buttonMutedMusic.SetActive(true);
        buttonNormalMusic.SetActive(false);
        audioController.GetComponent<AudioSource>().enabled=false;
        
    }

    public void unmuteMusic(){
        //GetComponent<AudioSource>().enabled=true;
        //GetComponent<AudioSource>().Play();

        PlayerPrefs.SetInt("!music",0);
        buttonMutedMusic.SetActive(false);
        buttonNormalMusic.SetActive(true);

        audioController.GetComponent<AudioSource>().enabled=true;
    }

    public void MuteBoth(){
        muteMusic();
        muteSound();
    }

    public void UnmuteBoth(){
        unmuteMusic();
        unmuteSound();
    }
}
