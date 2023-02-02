using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    public List<CarController> allCars;

    public List<CarController> additionalBoughtCars;

    public int numberOfCarsOnLevel;

    public List<CarController> cars;

    public Vector3 spawnPosition;

    public RunCarController runCarController;

    public GridRow gridRow;

    public GeneralCarMove generalCarMove;

    public GameObject skipButton;

    [HideInInspector]
    public int currentCartId = 0;

    [HideInInspector]
    public BaseUIController ui;

    void Start(){
        CarController.platformIsFree = true;
        currentCartId=0;

        ui=gameObject.GetComponent<BaseUIController>();

        skipButton.SetActive(false);

        cars.Clear();

        for(int i=0; i<numberOfCarsOnLevel; i++){
            cars.Add(allCars[i%(Backend.GetNumberOfAvailableCars()+1)]);
        }

        if(additionalBoughtCars.Count > 0){
            FillWithBoughtCars();
        }
        
        Spawn();
    }

    void FillWithBoughtCars(){
        for(int i=0; i<additionalBoughtCars.Count; i++){
            Debug.Log(Shop.CarIsAvailable(i) + " is available: " + i.ToString());
            if(Shop.CarIsAvailable(i)/* && Random.Range(1, 4) == 2*/){
                cars[Random.Range(0, cars.Count)] = additionalBoughtCars[i];
            }
        }
    }

    void Update(){
        //Debug.Log("Platform is active: "+CarController.platformIsFree.ToString());
        //checkGameState();
    }

    public void Spawn(){
        currentCartId++;

        if(currentCartId>=cars.Count){
            skipButton.SetActive(true);
        }
        
        if(!CarController.platformIsFree)return;

        CarController.platformIsFree = false;

        CarController car = cars[currentCartId];

        Debug.Log(currentCartId);

        if(currentCartId>cars.Count)return;

        var newCar = Instantiate(car.gameObject, spawnPosition, car.gameObject.transform.rotation) as GameObject;

        runCarController.car = newCar.GetComponent<CarController>();
        newCar.GetComponent<CarController>().carSpawnController = this;

        generalCarMove.carMove = newCar.GetComponent<CarMove>();

        generalCarMove.carMove.Init(generalCarMove.sliderMove, generalCarMove.handler);
    }

    public void InvokeCheckGameState(){
        Invoke(nameof(checkGameState), 6f);
    }

    void checkGameState(){
        if(gridRow.checkGameState())return;
        if(currentCartId>=cars.Count){
            gridRow.LoseBehaviour();
            return;
        }
    }

    public void CancelCheckGameState(){
        if(IsInvoking(nameof(checkGameState)))CancelInvoke(nameof(checkGameState));
    }
}
