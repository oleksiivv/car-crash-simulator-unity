using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    public Text levelLabel;

    void Start(){
        levelLabel.text = Application.loadedLevel.ToString();
    }
}
