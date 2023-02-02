using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCoinController : MonoBehaviour
{
    public ParticleSystem effect;

    public void Collect(){
        effect.Play();
        effect.gameObject.transform.parent = null;

        Destroy(gameObject);

        Backend.SaveCurrentCoin();

        Backend.AddCoins(5);
    }
}
