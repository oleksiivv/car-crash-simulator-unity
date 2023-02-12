using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject studyPanel, fullStudyPanel;

    public bool show = true;

    public GameObject button;

    void Start(){
        if(show){
            ShowStudyPanel();
        }
    }

    public void ShowFullStudyPanel(){
        button.GetComponent<Animator>().enabled = false;
        fullStudyPanel.SetActive(true);
    }

    public void HideFullStudyPanel(){
        fullStudyPanel.SetActive(false);
    }

    public void ShowStudyPanel(){
        studyPanel.SetActive(true);
    }
}
