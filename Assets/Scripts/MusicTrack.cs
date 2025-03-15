using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicTrack : MonoBehaviour
{
    public static MusicTrack instance;
    public AudioSource theMusic;
    public Tracker[] guruGatra;
    public int counter = 0;

    private void Start()
    {
        instance = this;
    }

    [System.Serializable]
    public class Tracker
    {
        public string GuruWilangan;
        public int HitObject;
    }
}
