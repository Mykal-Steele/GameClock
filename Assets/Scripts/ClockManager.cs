using System.Collections;
using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    private int rplaytime = 600;
    private int lplaytime = 600;
    private int rseconds = 0;
    private int rminutes = 0;
    private int lseconds = 0;
    private int lminutes = 0;
    private string timeee;
    public bool rcplaying;
    public bool clockstopright;
    public float rclockgoing = 0;
    public float lclockgoing = 0;
    public TextMeshProUGUI rplaytimeshow = null;
    public TextMeshProUGUI lplaytimeshow = null;
    public void Start(){
        rplaytimeshow.text = timeee;
        lplaytimeshow.text = timeee;
        
    }
    public void RightClock(){
        rcplaying = true;
        StartCoroutine("RPlaytimer");
    }
    public void LeftClock(){
        rcplaying = false;
        StartCoroutine("LPlaytimer");
    }
    // Start is called before the first frame update
    private IEnumerator RPlaytimer()
    {
        if(rcplaying == true)
        {
            rclockgoing +=1;
            clockstopright = false;
            while (clockstopright == false)
            {
                yield return new WaitForSeconds(1);
                rplaytime -= 1;
                rseconds = (rplaytime % 60);
                rminutes = (rplaytime / 60) % 60;
                rUpdatePlaytimeText();
            }
        }
    }
    private IEnumerator LPlaytimer()
    {
        if(rcplaying == false)
        {
            clockstopright = true;
            while (true)
            {
                yield return new WaitForSeconds(1);
                lplaytime -= 1;
                lseconds = (lplaytime % 60);
                lminutes = (lplaytime / 60) % 60;
                lUpdatePlaytimeText();
            }
        }
    }
    void rUpdatePlaytimeText()
    {
        rplaytimeshow.text = rminutes.ToString() +" : " + rseconds.ToString();
    }
    void lUpdatePlaytimeText()
    {
        lplaytimeshow.text = lminutes.ToString() +" : " + lseconds.ToString();
    }
}
