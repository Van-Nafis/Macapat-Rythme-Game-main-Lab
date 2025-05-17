using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicTrack : MonoBehaviour
{
    public static MusicTrack instance;
    public AudioSource theMusic;
    public Tracker[] guruGatra;
    public int counter = 0;

    public Slider musicSlider;

    private bool isDragging = false;

    private void Start()
    {
        instance = this;
        theMusic.Stop();       
    }

    private void Update()
    {

    }

    // Ketika slider mulai di-drag
    public void OnPointerDown()
    {
        isDragging = true;
    }

    // Ketika slider dilepas
    public void OnPointerUp()
    {
        isDragging = false;
        theMusic.time = musicSlider.value; // Atur waktu pemutaran sesuai slider
    }

    // Ketika nilai slider berubah
    public void OnSliderChanged()
    {
        if (isDragging)
        {
            theMusic.time = musicSlider.value;
        }
    }

    [System.Serializable]
    public class Tracker
    {
        public string GuruWilangan;
        public int HitObject;
    }
}
