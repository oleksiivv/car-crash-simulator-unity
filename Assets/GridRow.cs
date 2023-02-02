using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRow : MonoBehaviour
{
    public int rowNumber = 1;

    public int minRequiredObjectsAmount = 1;

    public int maxRequiredObjectAmount = 5;

    [HideInInspector]
    public int currentAmountOfObjects = 0;

    public CarSpawnController carSpawnController;
    public WinUIController winController;
    public BaseUIController uiController;

    public GameOverUIController gameOverController;

    public GameObject skipButton;

    public BadgesGameManager badgesGameManager;

    void Start(){
        currentAmountOfObjects = 0;

        skipButton.SetActive(false);
    }

    void Update(){
        Debug.Log(carSpawnController.currentCartId.ToString() + "/" + carSpawnController.cars.Count.ToString());
        //if(!winController.winPanel.activeSelf)checkGameState();
    }

    public void addAimObject(){
        currentAmountOfObjects++;

        uiController.ShowProgress((100*currentAmountOfObjects)/maxRequiredObjectAmount);

        if (IsInvoking(nameof(checkGameState))) {
            CancelInvoke(nameof(checkGameState));
        }
       Invoke(nameof(checkGameState), 3f);

       if (currentAmountOfObjects >= minRequiredObjectsAmount)skipButton.SetActive(true);
    }

    public void checkGameStateHandler(){
        if(currentAmountOfObjects >= minRequiredObjectsAmount){
            if(currentAmountOfObjects >= (minRequiredObjectsAmount+maxRequiredObjectAmount)/2){
                
                carSpawnController.CancelCheckGameState();
                if(currentAmountOfObjects == maxRequiredObjectAmount){
                    winController.showWinPanel(3, 100);
                }
                else{
                    winController.showWinPanel(2, (100*currentAmountOfObjects)/maxRequiredObjectAmount);
                }
            }else{
                winController.showWinPanel(1, (100*currentAmountOfObjects)/maxRequiredObjectAmount);
            }
        }else{
            LoseBehaviour();
        }
    }

    public bool checkGameState(){
        if(currentAmountOfObjects >= minRequiredObjectsAmount && (carSpawnController.currentCartId >= carSpawnController.cars.Count || currentAmountOfObjects == maxRequiredObjectAmount)){
            if(currentAmountOfObjects >= (minRequiredObjectsAmount+maxRequiredObjectAmount)/2){
                
                carSpawnController.CancelCheckGameState();
                if(currentAmountOfObjects == maxRequiredObjectAmount){
                    //win behaviour(3 stars)
                    Debug.Log("3 stars");
                    Debug.Log("Current amount: "+currentAmountOfObjects.ToString()+"/"+maxRequiredObjectAmount.ToString());

                    //show win panel
                    winController.showWinPanel(3, 100);

                    if(carSpawnController.currentCartId == 1){
                        badgesGameManager.ReceiveBadge("From first try");
                    }
                }
                else{
                    skipButton.SetActive(true);
                    //win beehaviour(2 stars)
                    Debug.Log("2 stars");
                    Debug.Log("Current amount: "+currentAmountOfObjects.ToString()+"/"+maxRequiredObjectAmount.ToString());
                    Debug.Log("Current cars: "+carSpawnController.currentCartId.ToString()+"/"+carSpawnController.cars.Count.ToString());

                    if(carSpawnController.currentCartId >= carSpawnController.cars.Count){
                        //show win panel
                        winController.showWinPanel(2, (100*currentAmountOfObjects)/maxRequiredObjectAmount);
                    }
                }
            }else{
                skipButton.SetActive(true);
                //win behaviour(1 star)
                Debug.Log("1 star");
                Debug.Log("Current amount: "+currentAmountOfObjects.ToString()+"/"+maxRequiredObjectAmount.ToString());
                Debug.Log("Current cars: "+carSpawnController.currentCartId.ToString()+"/"+carSpawnController.cars.Count.ToString());

                if(carSpawnController.currentCartId >= carSpawnController.cars.Count){
                    badgesGameManager.ReceiveBadge("Joker");
                    //show win panel
                    winController.showWinPanel(1, (100*currentAmountOfObjects)/maxRequiredObjectAmount);
                }
            }

            if(Application.loadedLevel < 3){
                badgesGameManager.ReceiveBadge("Master-newbie");
            }

            return true;
        }else{
            return false;
        }
    }

    public void LoseBehaviour(){
        gameOverController.GameOver((100*currentAmountOfObjects)/maxRequiredObjectAmount);
    }
}
