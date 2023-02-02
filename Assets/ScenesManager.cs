using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Image loadingPanel;

    public Sprite[] backgrounds;

    private static int sceneReopeningTimes = 0;

    private int sceneId=0;

    public void OpenScene(int id){
        loadingPanel.GetComponent<Image>().sprite = backgrounds[sceneReopeningTimes%backgrounds.Length];
        sceneReopeningTimes++;
        loadingPanel.gameObject.SetActive(true);
        Time.timeScale=1;

        sceneId=id;

        Invoke(nameof(StartAsyncLoading), 0.3f);
    }

    void StartAsyncLoading(){
        Application.LoadLevelAsync(sceneId);
    }
}
