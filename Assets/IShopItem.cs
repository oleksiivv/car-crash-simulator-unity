using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItem {
    public bool IsAvailable();

    public bool Buy(int price=0);
}
