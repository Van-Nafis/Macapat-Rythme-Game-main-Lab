using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MusicTrack))]
public class GameManager : MonoBehaviour
{
    public MusicTrack music;

    public bool startPlaying;

    public BeatsController theBC;

    public static GameManager instance;
    public static int a;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public Text highScoreText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float comboHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, comboText, perfectsText, missesText, rankText, finalScoreText;

    private bool medaliSudahDipanggil = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
        music = gameObject.GetComponent<MusicTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore();

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBC.hasStarted = true;

                music.theMusic.Play();

            }
        }
        else
        {
            if(!music.theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                comboText.text = comboHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits + comboHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";
                
                if (percentHit > 40)
                {
                    rankVal = "D";
                    if(percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }

        medali();
    }

    public void NoteHit()
    {
        /*Debug.Log("Hit On Time");*/

        if (currentMultiplier - 1 < multiplierThreshold.Length)
        {
            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }
    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }

    public void ComboHit()
    {
        currentScore += 25;
        NoteHit();

    }

    public void highScore()
    {
        highScoreText.text = "High Score :\n" + PlayerPrefs.GetInt("HighScore");
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score :\n" + PlayerPrefs.GetInt("HighScore", 0);
        }
    }

    public void medali()
    {
        if (medaliSudahDipanggil) return;

        if (normalHits + goodHits + perfectHits + missedHits == totalNotes)
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            int currentFinishCount = PlayerPrefs.GetInt(sceneKey, 0);
            PlayerPrefs.SetInt(sceneKey, currentFinishCount + 1);
            PlayerPrefs.Save();

            medaliSudahDipanggil = true;
        }
    }
}
