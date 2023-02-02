using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarToBeOpenedShopItem : MonoBehaviour, IShopItem
{
    public ShopController shop;

    public int id;

    public bool IsAvailable(){
        return Backend.GetNumberOfAvailableCars() > this.id;
    }

    public bool Buy(int price=0){
        return false;
    }

    private void OnMouseDown() {
        // if(shop.openCarPanel.activeSelf){
        //     shop.CloseCarToOpenPanel();
        // } else{
        //     shop.OpenCarToOpenPanel(this.id);
        // }
        shop.OpenCarToOpenPanel(this.id);
    }
}
