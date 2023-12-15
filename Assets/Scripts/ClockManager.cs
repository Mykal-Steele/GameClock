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
    public GameObject leftblock;
    public GameObject clickHereToStart;
    public AudioSource clock;
    public TextMeshProUGUI rplaytimeshow = null;
    public TextMeshProUGUI lplaytimeshow = null;
    public bool hasRunR = false;
    private bool hasRunL = false;
    public float spampreventr =0;
    public float spampreventl = 5f;
    public GameObject LeftClockTImBg;
    public GameObject RightClockTimBg;
    public void Start(){
        LeftClockTImBg.SetActive(false);
        RightClockTimBg.SetActive(false);
        rplaytimeshow.text = timeee;
        lplaytimeshow.text = timeee;
        clock = GetComponent<AudioSource>();
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
    // Start is called before the first frame update
    private IEnumerator RPlaytimer()
    {
        clock.Play();
        
        clickHereToStart.SetActive(false);
        
        if(rcplaying == true && rclockgoing == 0 && lrunning == false && spampreventl > 3f)
        {
            
            spampreventl = 0;
            
            clockstopright = false;
            while(clockstopright == false)
            {
                yield return new WaitForSeconds(0.1f);
                spampreventr++;
                if(spampreventr > 3f){
                    break;
                }
            }
            hasRunL = false;
            
            
            rclockgoing +=1;
            lclockgoing -= 1;
            
            while (clockstopright == false)
            {   
                if(hasRunR == false)
                {
                    yield return new WaitForSeconds(0.3f);
                    hasRunR = true;
                }
                leftblock.SetActive(false);
                RightClockTimBg.SetActive(true);
                LeftClockTImBg.SetActive(false);
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
        clock.Play();
        
        if(rcplaying == false && lclockgoing == -1 && spampreventr > 3f)
        {
            
            spampreventr = 0;
            clockstopright = true;
            while(clockstopright == true)
            {
                yield return new WaitForSeconds(0.1f);
                spampreventl++;
                if(spampreventl > 3f){
                    break;
                }
            }
            
            hasRunR = false;
            
            rclockgoing -=1;
            lclockgoing += 1;
            
            while (clockstopright == true)
            {     
                if(hasRunL == false){
                    yield return new WaitForSeconds(0.3f);
                    hasRunL = true;
                }
                RightClockTimBg.SetActive(false);
                LeftClockTImBg.SetActive(true);
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
        string formattedTime = $"{rminutes:00} : {rseconds:00}";
        rplaytimeshow.text = formattedTime;
    }

    void lUpdatePlaytimeText()
    {
        string formattedTime = $"{lminutes:00} : {lseconds:00}";
        lplaytimeshow.text = formattedTime;
    }
}
