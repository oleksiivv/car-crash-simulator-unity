using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public List<SingleAimObject> singleAimObjects;

    public ParticleSystem effect;

    public CoinsSpawner coinsSpawner;

    private bool coinsSpawned=false;

    private int readyItems = 0;

    void Start(){
        if(singleAimObjects[0].animateBuidlingOnStart){
            effect.Play();
        }
    }

    public void FinishItem(){
        readyItems++;

        if(readyItems == singleAimObjects.Count){
            foreach(var aimObject in singleAimObjects)aimObject.FinishItem();
        }

        if(!IsInvoking(nameof(SpawnCoins)) && !coinsSpawned){
            coinsSpawned = true;
            Invoke(nameof(SpawnCoins), 1f);
        }
    }

    void SpawnCoins(){
        coinsSpawner.Spawn();
    }
}
