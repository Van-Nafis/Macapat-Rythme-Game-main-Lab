using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalControler : MonoBehaviour
{
    public Text jmlhGameSelesai;
    public Image TargetImage;
    public Sprite M1, M2, M3, M4, M5, M6, M7, M8;

    // Start is called before the first frame update
    void Start()
    {
        int jmlhSelesai = PlayerPrefs.GetInt(gameObject.name, 0);
        jmlhGameSelesai.text = jmlhSelesai.ToString();

        if (jmlhSelesai >= 35)
        {
            TargetImage.sprite = M8;
        }
        else if (jmlhSelesai >= 30)
        {
            TargetImage.sprite = M7;
        }
        else if (jmlhSelesai >= 25)
        {
            TargetImage.sprite = M6;
        }
        else if (jmlhSelesai >= 20)
        {
            TargetImage.sprite = M5;
        }
        else if (jmlhSelesai >= 15)
        {
            TargetImage.sprite = M4;
        }
        else if (jmlhSelesai >= 10)
        {
            TargetImage.sprite = M3;
        }
        else if (jmlhSelesai >= 5)
        {
            TargetImage.sprite = M2;
        }
        else
        {
            TargetImage.sprite = M1;
        }
    }
}
