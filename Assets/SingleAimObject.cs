using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAimObject : MonoBehaviour
{
    [HideInInspector]
    public bool alreadyOnAim = false;

    public int aimRowNumber = -1;

    //todo: tmp while we do not check magnitude
    public GridRow aimRow;

    public bool animateBuidlingOnStart;

    private bool animateBuidlingOnStartNotFinished=false;

    private Vector3 startPosition;

    public BuildingController buildingController;

    void Start(){
        alreadyOnAim = false;
        animateBuidlingOnStartNotFinished=false;

        if(animateBuidlingOnStart){
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            startPosition = gameObject.transform.position;
            gameObject.transform.position+=new Vector3(Random.Range(-10f, 10f), 5.5f, Random.Range(-10f, 10f));

            animateBuidlingOnStartNotFinished=true;

            StartCoroutine(AnimateBuidling());
        }
    }

    IEnumerator AnimateBuidling(){
        while(transform.position.y != startPosition.y){
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.2f);

            yield return new WaitForSeconds(0.01f);
        }

        buildingController.FinishItem();
    }

    public void FinishItem(){
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        Invoke(nameof(UseGravity), 0.6f);
        animateBuidlingOnStart = false;
    }

    void UseGravity(){
        gameObject.GetComponent<Rigidbody>().useGravity = true;

        Invoke(nameof(startGame), 2f);
    }

    void startGame(){
        animateBuidlingOnStartNotFinished=false;
    }

    private void Update() {
        if(aimRowNumber == 0){
            //check magnitude
        }   
    }

    //todo: tmp while we do not check magnitude
    private void OnCollisionEnter(Collision other) {
        if(aimRowNumber == 0 && !animateBuidlingOnStart){
            if(other.gameObject.tag.ToLower().Equals("car")){
                if(!alreadyOnAim) aimRow.addAimObject();
                alreadyOnAim = true;
            }
            else if(other.gameObject.tag.ToLower().Equals("aimobject") && !animateBuidlingOnStartNotFinished){
                if(other.gameObject.GetComponent<SingleAimObject>().alreadyOnAim){
                    if(!alreadyOnAim) aimRow.addAimObject();
                    alreadyOnAim = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.ToLower().Equals("row") && !animateBuidlingOnStart && !animateBuidlingOnStartNotFinished){
            var row = other.gameObject.GetComponent<GridRow>();

            if(row.rowNumber == aimRowNumber){
                if(!alreadyOnAim) row.addAimObject();
                alreadyOnAim = true;
            }
        }    
    }
}
