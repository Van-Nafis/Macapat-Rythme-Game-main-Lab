using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    public AudioSource backgroundAudio;

    // Tambahkan nama-nama scene yang tidak ingin memutar audio
    public List<string> excludedScenes;

    private static BGMManager instance;

    void Awake()
    {
        // Singleton: agar tidak ada dua audio manager saat scene berpindah
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Hapus duplikat
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (excludedScenes.Contains(scene.name))
        {
            if (backgroundAudio.isPlaying)
                backgroundAudio.Pause(); // Bisa pakai Stop() juga
        }
        else
        {
            if (!backgroundAudio.isPlaying)
                backgroundAudio.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
