using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacapatPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] macapatClips;
    public MusicSlider musicSlider;

    public void Start()
    {
        CheckAudioSource();
    }

    public void PlayMacapatByIndex(int index)
    {
        Debug.Log("Audio Clip yang sedang diputar" + macapatClips[index]);
        if (index >= 0 && index < macapatClips.Length)
        {
            audioSource.clip = macapatClips[index];

            // Update slider agar sesuai durasi lagu baru
            musicSlider.UpdateSliderForNewClip();
        }

        FindObjectOfType<ToogleBtn>().SetToPause(); // Mengaktifkan icon play saat berganti AudioClip aktif

    }

    public void CheckAudioSource()
    {
        if (audioSource.clip == null)
        {
            audioSource.clip = macapatClips[0];
        }

        // Set nilai maksimum slider sesuai durasi lagu
        musicSlider.slider.maxValue = audioSource.clip.length;
    }
}
