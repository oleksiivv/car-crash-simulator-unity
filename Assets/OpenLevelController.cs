using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelController : MonoBehaviour
{
    public int level;

    public GameObject openLevelBarrier;

    public List<MeshRenderer> stars;

    public Material activeStar, nonActiveStar;

    public ScenesManager scenesManager;  

    void Start(){
        if(Backend.LevelIsCompleted(level) == 1){
            SetAllStarsActive(true);
        }else{
            SetAllStarsActive(false);
        }

        for(int i=0; i<stars.Count; i++){
            if(i<Backend.GetLevelStars(level)){
                stars[i].material = activeStar;
            } else{
                stars[i].material = nonActiveStar;
            }
        }
    }

    void SetAllStarsActive(bool active){
        foreach(var star in stars)star.gameObject.SetActive(active);
    }

    private void OnMouseUp() {
        if(openLevelBarrier.activeSelf)return;
        
        if(level==1 || Backend.LevelIsCompleted(level-1)==1){
            scenesManager.OpenScene(level);
        }
    }
}
