using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    private float startTime;
    public static string timeString;
    private static float t;
    public Text time;
    private string minutes;
    private string seconds;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.time - startTime;
        minutes = ((int) t/60).ToString();
        seconds = (t % 60).ToString("f1");
        this.time.text = "Time: "+minutes+ ":" +seconds;
        timeString = minutes+":"+seconds;
    }

    public static float GetRealTime() {
        return t;
    }

    public static string GetStringTime() {
        return timeString;
    }
}
