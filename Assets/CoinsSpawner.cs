using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public List<GameObject> coins;

    public Vector2 dxPos, dzPos;

    public float yPos;

    public int amount;

    public void Spawn(){
        amount = amount - Backend.CoinsSavedInLevel() > 0
            ? amount - Backend.CoinsSavedInLevel()
            : 0;

        for(int i=0; i<amount; i++){
            int n = Random.Range(0, coins.Count);

            Instantiate(coins[n], new Vector3(Random.Range(dxPos.x, dxPos.y), yPos, Random.Range(dzPos.x, dzPos.y)), coins[n].transform.rotation);
        }
    }
}
