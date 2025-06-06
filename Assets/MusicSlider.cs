using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public Text currentTimeText;

    private bool isDragging = false;

    void Start()
    {

    }

    void Update()
    {
        if (!isDragging)
        {
            if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
            {
                // Musik sudah selesai
                slider.value = 0;
                currentTimeText.text = FormatTime(0);
                audioSource.time = 0;

                // Kembalikan UI play/pause ke play
                FindObjectOfType<ToogleBtn>().SetToPause();
            }
            else
            {
                // Update posisi slider saat audio berjalan
                slider.value = audioSource.time;
                currentTimeText.text = FormatTime(audioSource.time);
            }
        }
    }

    // Dipanggil saat mulai drag
    public void OnPointerDown()
    {
        isDragging = true;
    }

    // Dipanggil saat selesai drag
    public void OnPointerUp()
    {
        isDragging = false;
        audioSource.time = slider.value;
    }

    // Dipanggil saat slider digeser (jika ingin update real-time saat drag)
    public void OnSliderValueChanged(float value)
    {
        if (isDragging)
        {
            audioSource.time = value;
            currentTimeText.text = FormatTime(value);
        }
    }

    public void UpdateSliderForNewClip()
    {
        if (audioSource.clip != null)
        {
            slider.maxValue = audioSource.clip.length;
        }
    }

    private string FormatTime(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
}
