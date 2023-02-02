using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPanelShow : MonoBehaviour
{
    public GameObject[] components;

    public float delay=2f;

    public GameObject profilePanel;

    void Start(){
        foreach(var component in components){
            component.SetActive(false);
        }

        Invoke(nameof(show), delay);
    }

    void show(){
        foreach(var component in components){
            component.SetActive(true);
        }

        if(profilePanel)profilePanel.SetActive(true);
    }
}
