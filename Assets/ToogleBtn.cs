using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToogleBtn : MonoBehaviour
{
    public Image imagePlay;
    public Image imagePause;
    public Button toggleButton;
    public MacapatPlayer macapatPlayer;
    public bool musikSedangAktif;

    void Start()
    {

        // Set kondisi awal
        imagePlay.enabled = true;
        imagePause.enabled = false;

        // Tambahkan listener ke tombol
        toggleButton.onClick.AddListener(SwitchImage);
    }

    void SwitchImage()
    {
        bool musikSedangAktif = imagePlay.enabled;
        Debug.Log("Musik sedang aktif " + musikSedangAktif);

        if (!musikSedangAktif)
        {
            macapatPlayer.audioSource.Pause();
        }
        else
        {
            macapatPlayer.audioSource.Play();
        }

        // Ubah gambar tombol
        imagePlay.enabled = !musikSedangAktif;
        imagePause.enabled = musikSedangAktif;
    }

    public void SetToPause()
    {
        imagePlay.enabled = true;
        imagePause.enabled = false;
    }


}
