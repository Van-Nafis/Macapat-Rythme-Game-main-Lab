using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MedalBoardMover : MonoBehaviour
{
    public RectTransform MedalBoard;       // Drag tombol UI ke sini
    public float jarakGeser = 700f;     // Jarak gerakan ke kanan
    public float durasiGerak = 0.3f;    // Durasi animasi (dalam detik)
    private bool keKanan = true;        // Toggle arah
    private bool sedangGerak = false;   // Cegah spam klik saat bergerak

    public void GeserTombol()
    {
        if (!sedangGerak)
        {
            Vector2 posisiAwal = MedalBoard.anchoredPosition;
            Vector2 posisiTarget = posisiAwal + new Vector2(keKanan ? jarakGeser : -jarakGeser, 0);

            StartCoroutine(AnimasiGerak(posisiAwal, posisiTarget));
            keKanan = !keKanan;
        }
    }

    IEnumerator AnimasiGerak(Vector2 dari, Vector2 ke)
    {
        sedangGerak = true;

        float waktu = 0;
        while (waktu < durasiGerak)
        {
            MedalBoard.anchoredPosition = Vector2.Lerp(dari, ke, waktu / durasiGerak);
            waktu += Time.deltaTime;
            yield return null;
        }

        MedalBoard.anchoredPosition = ke;
        sedangGerak = false;
    }
}
