using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [HideInInspector]
    public CarSpawnController carSpawnController;

    private Rigidbody rigidbody;

    [HideInInspector]
    public bool canMove=false;

    public static bool platformIsFree=true;

    private AudioCarEffects audioCarEffects;

    private CarMove carMove;

    private bool wasJustCreated=true;

    void Start(){
        rigidbody = gameObject.GetComponent<Rigidbody>();

        canMove=false;

        audioCarEffects = gameObject.GetComponent<AudioCarEffects>();

        carMove = gameObject.GetComponent<CarMove>();

        Invoke(nameof(UpdateWasJustCreatedFlag), 1f);
    }

    void UpdateWasJustCreatedFlag(){
        wasJustCreated=false;
    }

    private bool alreadyIn=false;

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "platform"){
            canMove=true;
        }
        else if(other.gameObject.tag == "coin"){
            other.gameObject.GetComponent<SingleCoinController>().Collect();

            carSpawnController.ui.ShowCoinsAmount();

            audioCarEffects.PlayCoinGetEffect();
        }
        else{
            platformIsFree=true;
            carSpawnController.InvokeCheckGameState();
            if(!alreadyIn){
                carSpawnController.Spawn();
            }
            alreadyIn=true;

            audioCarEffects.PlayGameSmash();

            carMove.runFX.Stop();
            //Destroy(this);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "platform" && !wasJustCreated){
            canMove=false;
            Destroy(gameObject.GetComponent<CarMove>());
        }
    }

    public void Move(float force){
        if(canMove){
            rigidbody.velocity = Vector3.left*force;
        }
    }
}
