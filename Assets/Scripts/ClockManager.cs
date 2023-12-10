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
    private bool hasStarted = false;
    private bool lrunning = false;
    private bool rrunning = false;
    public TextMeshProUGUI rplaytimeshow = null;
    public TextMeshProUGUI lplaytimeshow = null;
    public void Start(){
        rplaytimeshow.text = timeee;
        lplaytimeshow.text = timeee;
    }
    public void RightClock(){
        rcplaying = true;
        StartCoroutine("RPlaytimer");
        hasStarted = true;
    }
    public void LeftClock(){
        if(hasStarted == true)
        {
            rcplaying = false;
            StartCoroutine("LPlaytimer");
        }
    }
    private IEnumerator SpamPrevent()
    {
            print("It work?");
            yield return new WaitForSeconds(1);
            lrunning = false;
            print("it done");

    }
    private IEnumerator SpamPrevents()
    {
            print("It work?");
            yield return new WaitForSeconds(1);
            rrunning = false;
            print("it done");

    }
    // Start is called before the first frame update
    private IEnumerator RPlaytimer()
    {
        rrunning = true;
        if(lrunning == true)
            {
                StartCoroutine("SpamPrevent");
            }
        if(rcplaying == true && rclockgoing == 0 && lrunning == false)
        {
            
            rclockgoing +=1;
            lclockgoing -= 1;
            clockstopright = false;
            while (clockstopright == false)
            {        
                rplaytime -= 1;
                rseconds = (rplaytime % 60);
                rminutes = (rplaytime / 60) % 60;
                rUpdatePlaytimeText();
                yield return new WaitForSeconds(1);
            }
        }
    }
    private IEnumerator LPlaytimer()
    {
        lrunning = true;
        if(rrunning == true)
            {
                StartCoroutine("SpamPrevents");
                
            }
        if(rcplaying == false && lclockgoing == -1 && rrunning == false)
        {
            
            rclockgoing -=1;
            lclockgoing += 1;
            clockstopright = true;
            while (clockstopright == true)
            {     
                lplaytime -= 1;
                lseconds = (lplaytime % 60);
                lminutes = (lplaytime / 60) % 60;
                lUpdatePlaytimeText();
                yield return new WaitForSeconds(1);
            }
        }
    }
    private void Update(){
        if(rclockgoing > 1)
        {
            rclockgoing = 1;
        }
        if(lclockgoing > 0)
        {
            rclockgoing = 0;
        }
        if(lclockgoing < -1)
        {
            lclockgoing = -1;
        }
        if(rclockgoing <0){
            rclockgoing = 0;
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
