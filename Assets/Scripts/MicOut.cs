using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicOut : MonoBehaviour
{
    int i = 0;
    float maxLoudnessInInterval = 0;
    void Update()
    {
        if(i==0)
            maxLoudnessInInterval = 0;
        i+=1;
        if (MicInput.MicLoudness > maxLoudnessInInterval)
            maxLoudnessInInterval = MicInput.MicLoudness;
        if (i == 100)
        {
            i = 0;
            float usedLoudness = maxLoudnessInInterval * 1000;
            //_ShowAndroidToastMessage(usedLoudness.ToString());
            if (usedLoudness > 600)
            {
                _ShowAndroidToastMessage("That's too loud. Relax everyone can hear you!\n Current Volume = " + usedLoudness.ToString());
            }
            else if (usedLoudness < 100)
            {
                _ShowAndroidToastMessage("Speak up. You can do it!\n Current Volume = " + usedLoudness.ToString());
            }
            else
            {
                _ShowAndroidToastMessage("You are doing great. Keep it up!\n Current Volume = " + usedLoudness.ToString());
            }
        }
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
