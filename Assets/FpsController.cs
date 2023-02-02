using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public Text fpsCount;

    public GameObject debugPanel;

    public bool isDebug;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 40;

        debugPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fpsCount.GetComponent<Text>().text = "FPS: " + ((int)(1f / Time.unscaledDeltaTime)).ToString() ;
    }
}
