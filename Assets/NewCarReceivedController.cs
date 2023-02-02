using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCarReceivedController : MonoBehaviour
{
    public bool hasNewCar;

    public GameObject newCarPanel;

    public Image newCarIcon;

    public Sprite newCarSprite;

    private void Start() {
        newCarPanel.SetActive(false);
    }

    public void AddNewCarIfHas(){
        if(hasNewCar && Backend.CarAlreadyGiven(Application.loadedLevel) != 1){
            newCarPanel.SetActive(true);
            newCarIcon.GetComponent<Image>().sprite = newCarSprite;

            Backend.SaveNewCar();
            Backend.SetCarAlreadyGiven(Application.loadedLevel, 1);
        }
    }
}
