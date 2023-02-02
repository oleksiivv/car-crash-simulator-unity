using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public List<CarToBeOpenedShopItem> carsToBeOpened;

    public List<CarToBeBoughtShopItem> carsToBeBought;

    public List<GameObject> carsToOpenPadlocks;

    public List<GameObject> carsToBuyPadlocks;

    public GameObject openCarPanel;

    public GameObject buyCarPanel;

    public List<int> prices;

    public List<string> namesOfCarsToBought, namesOfCarsToOpen;

    public Image carToOpenIcon, carToBuyIcon;

    public List<Sprite> carsToOpenSprites, carsToBuySprites;

    public List<string> descriptionsForOpen;

    public string descriptionToBought;

    public Text carPriceInBuyPanel;

    public Text carNameInBuyPanel;

    public Text carNameInOpenPanel;

    public Text descriptionInBuyPanel, descriptionInOpenPanel;

    public Text coinsAmount;

    private void ShowCoinsAmount(){
        coinsAmount.text = Backend.GetCoins().ToString();
    }

    void Start(){
        for(int i=0; i<carsToBeOpened.Count; i++){
            carsToOpenPadlocks[i].SetActive(!carsToBeOpened[i].IsAvailable());
        }

        if(Backend.GetFirstShopOpenState() == 0){
            Backend.AddCoins(80);
            Backend.SetIsFirstShopOpenState(1);
        }

        UpdateBuyPadlocks();

        ShowCoinsAmount();
    }

    private void UpdateBuyPadlocks(){
        for(int i=0; i<carsToBuyPadlocks.Count; i++){
            carsToBuyPadlocks[i].SetActive(!carsToBeBought[i].IsAvailable());
        }
    }

    public void OpenCarToOpenPanel(int carId){
        CloseCarBuyPanel();
        
        openCarPanel.SetActive(true);

        descriptionInOpenPanel.text = descriptionsForOpen[carId];
        carNameInOpenPanel.text = namesOfCarsToOpen[carId];

        carToOpenIcon.GetComponent<Image>().sprite = carsToOpenSprites[carId];
    }

    public void CloseCarToOpenPanel(){
        openCarPanel.SetActive(false);
    }

    private int choosenCarIdForBought;

    public void OpenCarToBuyPanel(int carId){
        CloseCarToOpenPanel();

        if(carsToBeBought[carId].IsAvailable()){
            OpenCarToBuyPanelAfterBuying(carId);
            return;
        }

        buyCarPanel.SetActive(true);

        descriptionInBuyPanel.text = descriptionToBought;
        carNameInBuyPanel.text = namesOfCarsToBought[carId];
        carPriceInBuyPanel.text = prices[carId].ToString();

        carToBuyIcon.GetComponent<Image>().sprite = carsToBuySprites[carId];

        choosenCarIdForBought=carId;
    }

    public void OpenCarToBuyPanelAfterBuying(int carId){
        CloseCarBuyPanel();
        CloseCarBuyPanel();

        openCarPanel.SetActive(true);

        descriptionInOpenPanel.text = "";
        carNameInOpenPanel.text = namesOfCarsToBought[carId];

        carToOpenIcon.GetComponent<Image>().sprite = carsToBuySprites[carId];
    }

    public void CloseCarBuyPanel(){
        buyCarPanel.SetActive(false);
    }

    public void BuyCar(){
        int price = prices[choosenCarIdForBought];

        Debug.Log("Item: "+choosenCarIdForBought.ToString());
        Debug.Log("Price: "+price.ToString());

        if(!carsToBeBought[choosenCarIdForBought].IsAvailable() && Backend.GetCoins() >= price){
            carsToBeBought[choosenCarIdForBought].Buy(price);

            UpdateBuyPadlocks();

            OpenCarToBuyPanelAfterBuying(choosenCarIdForBought);

            ShowCoinsAmount();
        }
    }
}
