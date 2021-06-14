using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundSensivity : MonoBehaviour
{
    public float sensivity = 0;
    public float loudness = 0;

    public Text loudLevel;
    public Text action;
    AudioSource audioS;
    private int hi;
    float lou;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lou = 0;
        hi = 0;
        audioS = GetComponent<AudioSource>();
        audioS.clip = Microphone.Start(null, true, 10, 44100);
        audioS.loop = true;
        audioS.mute = false;
        anim = GetComponent<Animator>();
        while (!(Microphone.GetPosition(null) > 0)) {

            //Debug.Log("No Mic");
        }
        audioS.Play();

        audioS.volume = 0.01f;
        //aduioS.Mute = false;

    }

    // Update is called once per frame
    void Update()
    {
        loudness = GetAvgVol() * sensivity;
        if(loudness>lou)
        {
            lou = loudness;
        }
        Debug.Log(lou + "+"+loudness);
        //  ToS
        // to
       // _ShowAndroidToastMessage(loudness.ToString());
        // Debug.Log("Loudness :" + loudness);
        loudLevel.text="Loudness level +"+loudness.ToString();


        if (loudness >0.031 && loudness < 0.15 )     //Mild
        {
            //  this.GetComponent<>;
         //   _ShowAndroidToastMessage("Loud AF");
         
            action.text="Speak up...Pour everything out";
            anim.SetTrigger("Hit");
            Debug.Log("Sad Nigga hours");
            hi++;
            Debug.Log(hi);
        }


        if (loudness > 0.15 || hi>300)     //Mild
        {
            int yy;
            //  this.GetComponent<>;
        //    _ShowAndroidToastMessage("Loud AF");
        
            action.text="Felt Great?....Try Again";
            anim.SetTrigger("dead");
            Debug.Log("dead Nigga hours");
            Debug.Log(loudness);
            StartCoroutine(resetTheSCene());
        
            hi++;
            Debug.Log(hi);
        }

	
    }

    IEnumerator resetTheSCene()
    {
        yield return new WaitForSeconds(3);        
            action.text="Lets do it again";
            hi = 0;
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		

    }

    float GetAvgVol()
    {
        float[] data = new float[256];
        float a = 0;
        audioS.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
         //   Debug.Log("Value of a :" + a);
        }
        return a / 256;
    }

	private void scenefucks()
	{
		
		

	}
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
