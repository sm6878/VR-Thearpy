using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.enabled = false;
    }

    public void GotoMedMountain()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("VRMeditation");
    }
    public void GotoMedForest()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("VRMeditation2");
    }

    public void GotoPB()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("PunchScene");
    }

    public void GotoPhobiaHeight()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("PhobiaHeight");
    }

    public void GotoPhobiaDark()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("PhobiaDark");
    }

    public void GotoPhobiaSpider()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene(3);
    }
    public void GotoBubblePop()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("VRGame");
    }

    public void GotoAudience()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("VRAudience");
    }

    public void GotoTherapy()
    {
        XRSettings.enabled = true;
        SceneManager.LoadScene("VRtherapist");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
