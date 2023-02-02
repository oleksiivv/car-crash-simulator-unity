using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgesBackend : MonoBehaviour
{
    public static int CheckIfHasBadge(string token){
        return PlayerPrefs.GetInt("badge_#"+token, 0);
    }

    public static void ReceiveBadge(string token){
        PlayerPrefs.SetInt("badge_#"+token, 1);
    }
}
