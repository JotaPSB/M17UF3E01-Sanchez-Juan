using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool startPlaying;

    public BeatScroller bs;

    public int currentScore;
    public int currentMultiplier;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int mulitplierTracker;
    public int[] multiplierThresholds;
    public static GameManager instance;
    public AudioSource music;


    public Text scoreText;
    public Text multiText;
    public Text start;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startPlaying = false;
       
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bs.hasStarted = true;
                music.Play();
                start.gameObject.SetActive(false);
            }
        }
        
    }

    public void NoteHit()
    {
        Debug.Log("Hit");
        
        mulitplierTracker++;
        if (multiplierThresholds[currentMultiplier - 1] == mulitplierTracker)
        {
            mulitplierTracker = 0;
            currentMultiplier++;
            multiText.text = "Multiplier: x" + currentMultiplier;
        }
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit() 
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMiss()
    {
        Debug.Log("Not hit");
        currentMultiplier = 1;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
