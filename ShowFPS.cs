using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public TMP_Text text;
    
    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if(timer <=0) avgFramerate = (int) (1f / timelapse);
        text.text = string.Format(display,avgFramerate.ToString());
    }
}
