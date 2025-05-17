using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGauge : MonoBehaviour
{
    public Image ImageBar, progressBar;

    public GameObject penandaGatra, penandaWilangan, barUntukPopUpGatra;

    public List<float> heightBar = new List<float>();
    public List<float> tinggiAkumulasiGatra = new List<float>();

    public int hitObjectTotal;

    public static BarGauge instance;

    public Text guruWilanganPrefab;

    void Start()
    {
        instance = this;

        barProgressCap();

        RectTransform rectTransform = ImageBar.GetComponent<RectTransform>();

        // Ubah hanya ukuran Y
        Vector2 newSize = rectTransform.sizeDelta;
        newSize.y = 750f;
        rectTransform.sizeDelta = newSize;
    }

    private void Update()
    {
        
    }

    public void barProgressCap() // Sudah fix, JANGAN DIAPAPAIN
    {
        // Ambil RectTransform dari ImageBar
        RectTransform rectTransform = ImageBar.GetComponent<RectTransform>();

        // Hitung tinggi total dan jumlah gatra
        float totalHeight = rectTransform.rect.height;
        int jmlhGuruGatra = MusicTrack.instance.guruGatra.Length;
        float gatraHeight = totalHeight / jmlhGuruGatra; // Tinggi tiap gatra

        // Posisi awal untuk penanda gatra
        float posY = totalHeight / 2; // Mulai dari atas (pivot di tengah)

        // PERHATIKAN VARIABEL INI, Variabel ini berfungsi untuk menentukan jarak antara tulisan dengan garis guru wilangan 
        float horizontalOffset = 200f;

        // Loop untuk setiap gatra
        for (int i = 0; i < jmlhGuruGatra; i++)
        {
            int divisionsForCurrentGatra = MusicTrack.instance.guruGatra[i].HitObject; // Jumlah pembagian untuk gatra ini
            float divisionHeight = gatraHeight / divisionsForCurrentGatra; // Tinggi tiap pembagian

            // Buat penanda gatra di awal setiap gatra dan buat penanda wilangannya di samping  penanda gatra
            GameObject tandaGatra = Instantiate(penandaGatra, ImageBar.transform);
            RectTransform gatraRect = tandaGatra.GetComponent<RectTransform>();
            gatraRect.anchoredPosition = new Vector2(0f, posY);
            tinggiAkumulasiGatra.Add(posY);

            /*Debug.Log(tinggiAkumulasiGatra[i]);*/
            /*Debug.Log($"Penanda Gatra {i + 1}: Posisi Y adalah {gatraRect.anchoredPosition.y}");*/  // Penanda gatra 

            // Buat guru Wilangan di samping tanda gatra
            Text instantiatedGuruWilangan = Instantiate(guruWilanganPrefab, ImageBar.transform);
            instantiatedGuruWilangan.text = MusicTrack.instance.guruGatra[i].GuruWilangan;
            RectTransform wilanganRect = instantiatedGuruWilangan.GetComponent<RectTransform>();
            wilanganRect.anchoredPosition = new Vector2(gatraRect.anchoredPosition.x + horizontalOffset, posY);

            /*Debug.Log("Berhasil diins tansikan");*/

            // Kurangi posisi Y untuk memulai pembagian di bawah gatra ini
            posY -= divisionHeight;
            heightBar.Add(divisionHeight);

            // Loop untuk setiap pembagian dalam gatra ini
            for (int j = 1; j < divisionsForCurrentGatra; j++)
            {
                // Instantiate penanda wilangan
                GameObject tandaWilangan = Instantiate(penandaWilangan, ImageBar.transform);

                // Atur posisi anchoredPosition
                RectTransform wilanganRectPenanda = tandaWilangan.GetComponent<RectTransform>();
                wilanganRectPenanda.anchoredPosition = new Vector2(0f, posY);

                /*Debug.Log($"Penanda Wilangan Gatra {i + 1}, Pembagian {j + 1}: Posisi Y adalah {wilanganRect.anchoredPosition.y}");*/

                // Kurangi posisi Y untuk pembagian berikutnya
                posY -= divisionHeight;
                heightBar.Add(divisionHeight);
            }
        }
        /*foreach (float heightBartotal in heightBar) // Untuk mengecek indeks di heighBar
        {
            Debug.Log(heightBartotal);
        }*/
    }

    // Gunakan coroutine untuk melakukan loop menambahkankan tinggi dari barGreen
    public void IncrementProgress()
    {
        StartCoroutine(IncrementProgressCoroutine());
    }

    private IEnumerator IncrementProgressCoroutine()
    {
        // Ambil RectTransform dari ImageFluid dan ImageBar
        RectTransform rectFluid = progressBar.GetComponent<RectTransform>();
        RectTransform rectTransform = ImageBar.GetComponent<RectTransform>();

        // Coba (PopUpGatra merubah box collider sesuai dengan bentuk rect terbaru)
        RectTransform rectPopUpGatra = barUntukPopUpGatra.GetComponent<RectTransform>();
        BoxCollider2D colliderPopUpGatra = barUntukPopUpGatra.GetComponent<BoxCollider2D>();

        // Hitung tinggi total dan jumlah gatra
        float totalHeight = rectTransform.rect.height;
        float currentHeight = rectFluid.sizeDelta.y; // Mulai dari tinggi saat ini

        // Menghitung indeks dari belakang ke depan
        int reverseIndex = heightBar.Count - NoteObject.counterWilanganTotal;
        /*Debug.Log(reverseIndex+" "+NoteObject.counterWilanganTotal+" "+heightBar.Count);*/
        if (reverseIndex >= 0 && reverseIndex <= heightBar.Count)
        {
            // Tambahkan tinggi baru ke fluid
            currentHeight += heightBar[reverseIndex-1];
            /*Debug.Log($"Menggunakan Indeks {reverseIndex}: {heightBar[reverseIndex]}");*/

            // Atur ukuran RectTransform
            Vector2 newSizeFluid = rectFluid.sizeDelta;
            newSizeFluid.y = currentHeight;
            rectFluid.sizeDelta = newSizeFluid;

            // Posisikan rectFluid ke tengah sesuai tinggi yang baru
            Vector2 newPosition = rectFluid.anchoredPosition;
            newPosition.y = -totalHeight / 2 + currentHeight / 2; // Pivot berada di tengah
            rectFluid.anchoredPosition = newPosition;

            /*Debug.Log($"Fluid Updated: Height = {currentHeight}, Position Y = {newPosition.y}");*/
        }
        else
        {
            Debug.LogWarning("HitObjectTotal sudah maksimal atau indeks tidak valid!");
        }

        // PopUpGatra (Merubah boxCollider2D sesuai dengan ukuran rectTransformnya)
        if (rectPopUpGatra != null && colliderPopUpGatra != null)
        {
            colliderPopUpGatra.size = rectPopUpGatra.rect.size;
            colliderPopUpGatra.offset = rectPopUpGatra.rect.center;
            Physics2D.SyncTransforms(); // hanya saat perlu
        }



        yield return null;
    }

}