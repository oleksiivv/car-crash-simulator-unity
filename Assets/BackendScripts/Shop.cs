using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static void BuyCar(int id){
        PlayerPrefs.SetInt("bought_car#"+id.ToString(), 1);
    }

    public static bool CarIsAvailable(int id){
        return PlayerPrefs.GetInt("bought_car#"+id.ToString(), 0) == 1;
    }
}
