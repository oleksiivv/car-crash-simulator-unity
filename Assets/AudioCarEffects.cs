using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCarEffects : MonoBehaviour
{
    private AudioSource audioSource;

    public List<AudioClip> carSmashClips;

    public AudioClip engineClip;

    public AudioClip winEffect, loseEffect, coinEffect;

    private bool startedGame=false;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();    
    }

    private bool canPlayGameSmash = true;
    public void PlayGameSmash(){
        if(PlayerPrefs.GetInt("!sound")==1 || !canPlayGameSmash)return;

        int n = Random.Range(0, carSmashClips.Count);

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = carSmashClips[n];
        audioSource.enabled = true;

        audioSource.Play();
        canPlayGameSmash=false;
        Invoke(nameof(CanPlayGameSmashAgain), 1f);
    }

    private void CanPlayGameSmashAgain(){
        canPlayGameSmash=true;
    }

    public void PlayCoinGetEffect(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = coinEffect;
        audioSource.enabled = true;

        audioSource.Play();
    }

    private bool winAlreadyPlayed=false;
    public void PlayWin(){
        if(PlayerPrefs.GetInt("!sound")==1 || winAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = winEffect;
        audioSource.enabled = true;

        audioSource.Play();
        winAlreadyPlayed=true;
    }

    private bool loseAlreadyPlayed=false;
    public void PlayLose(){
        if(PlayerPrefs.GetInt("!sound")==1 || loseAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = loseEffect;
        audioSource.enabled = true;

        audioSource.Play();
        loseAlreadyPlayed=true;
    }

    public void PlayEngine(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        startedGame = true;

        StopAllCoroutines();
        audioSource.enabled = false;
        audioSource.clip = engineClip;
        audioSource.enabled = true;

        audioSource.Play();

        StartCoroutine(MakeEngineLoud());
    }

    public void StopEngine(){
        if(PlayerPrefs.GetInt("!sound")==1)return;
        
        StopAllCoroutines();
        StartCoroutine(MakeEngineQuiet());
    }

    IEnumerator MakeEngineQuiet(){
        while(audioSource.volume>0){
            audioSource.volume -= 0.05f;
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator MakeEngineLoud(){
        while(audioSource.volume<0.5f){
            audioSource.volume += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
