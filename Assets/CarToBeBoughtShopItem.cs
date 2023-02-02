using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarToBeBoughtShopItem : MonoBehaviour, IShopItem
{
    public ShopController shop;

    public int id;

    public bool IsAvailable(){
        return Shop.CarIsAvailable(this.id);
    }

    public bool Buy(int price=0){
        Shop.BuyCar(this.id);
        Backend.SubCoins(price);

        return true;
    }

    private void OnMouseDown() {
        // if(shop.buyCarPanel.activeSelf){
        //     shop.CloseCarBuyPanel();
        // } else{
        //     shop.OpenCarToBuyPanel(this.id);
        // }
        shop.OpenCarToBuyPanel(this.id);
    }
}
