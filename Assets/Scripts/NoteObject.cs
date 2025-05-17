using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public GameObject targetObject, bodyObject;

    public string penanda;

    public Button btn;

    public bool isPressed = false;
    public bool isMouseUp = true;

    public static int counterWilanganTotal;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckPositionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnClicked()
    {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.5f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) >= 0f)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
    }

    /*public void cmbSpriteHide()
    {
        if (targetObject.transform.position.y == 0)
        {
            // Mendapatkan SpriteRenderer dari targetObject (GameObject 1)
            SpriteRenderer spriteRendererTarget = targetObject.GetComponent<SpriteRenderer>();

            // Memastikan spriteRenderer ada dan kemudian menyembunyikan sprite
            if (spriteRendererTarget != null)
            {
                spriteRendererTarget.enabled = false;  // Menyembunyikan sprite di GameObject 1
            }
        }
    }*/

    public void OnPointerDown()
    {
        // Mendapatkan komponen SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (canBePressed)
        {
            StartCoroutine(HoldCombo());
            Debug.Log($"Posisi Baru: {transform.position.y}");
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
                Debug.Log("Sprite berhasil dihilangkan inti");
            }
        }
    }

    public void OnPointerUp()
    {
        // Mendapatkan SpriteRenderer dari targetObject (GameObject 1)
        SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererBody = bodyObject.GetComponent<SpriteRenderer>();

        if (canBePressed)
        {
            // Memastikan spriteRenderer ada dan kemudian menyembunyikan sprite
            if (spriteRenderer != null && spriteRendererBody != null)
            {
                // Menyembunyikan sprite
                spriteRenderer.enabled = false;
                spriteRendererBody.enabled = false;
            }

            else
            {
                Debug.Log("spriteRenderer = null atau spriteRendererBody = null");
            }
        }

        StopCoroutine(HoldCombo());
        isPressed = false;
    }

    // IEnumerator coba
    private IEnumerator HoldCombo()
    {
        isPressed = true;
        GameManager.instance.comboHits++;
        while (isPressed && canBePressed)
        {
            // Tambahkan efek kombo atau visual jika diperlukan
            Vector3 effectPositionGood = new Vector3(transform.position.x, 1, transform.position.z);
            Instantiate(goodEffect, effectPositionGood, goodEffect.transform.rotation);

            GameManager.instance.ComboHit();
            yield return new WaitForSeconds(0.25f);

            Debug.Log("Combo Berhasil");
        }
    }
    // Akhir dari IEnumerator coba

    public IEnumerator CheckPositionCoroutine()
    {
        while (targetObject != null) // Pastikan targetObject tidak null
        {
            if (targetObject.transform.position.y <= 0.1) // Membandingkan posisi y dengan 0 (menghindari masalah floating point)
            {
                SpriteRenderer spriteRendererTarget = targetObject.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRendererBody = bodyObject.GetComponent<SpriteRenderer>();

                /*Debug.Log("Sprite didapatkan");*/

                if (spriteRendererTarget != null) // Pastikan SpriteRenderer ada
                {
                    spriteRendererTarget.enabled = false; // Menyembunyikan sprite

                    /*Debug.Log("Sprite berhasil dihilangkan (Y == 0)");*/
                    canBePressed = false;

                    if (isPressed)
                    {
                        Vector3 effectPositionPerfect = new Vector3(transform.position.x, 1, transform.position.z);
                        Instantiate(perfectEffect, effectPositionPerfect, transform.rotation);
                        StopCoroutine(HoldCombo());
                        Debug.Log("Perfect muncul");
                    }
                }
                if (spriteRendererBody != null)
                {
                    spriteRendererBody.enabled = false;
                    /*Debug.Log("Body dihilangkan");*/
                }
                yield break; // Keluar dari Coroutine setelah kondisi terpenuhi
            }
            yield return null; // Tunggu 0.1 detik sebelum pengecekan berikutnya
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == penanda)
        {
            canBePressed = true;
            BarGauge.instance.IncrementProgress();
        }
        if (GameManager.instance.music.guruGatra[GameManager.instance.music.counter].HitObject >= 2)
        {
            GameManager.instance.music.guruGatra[GameManager.instance.music.counter].HitObject = GameManager.instance.music.guruGatra[GameManager.instance.music.counter].HitObject - 1;
            /*Debug.Log(GameManager.instance.music.guruGatra[GameManager.instance.music.counter].HitObject);*/
        }
        else
        {
            GameManager.instance.music.counter += 1;
            /*Debug.Log("Berhasil Tambah");*/
        }
        counterWilanganTotal += 1;
        /*Debug.Log(counterWilanganTotal);*/
        /*Debug.Log(GameManager.instance.music.counter);*/

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            
            if (collision.tag == penanda)
            {
                if (isPressed == true)
                {
                    canBePressed = true;
                }
                else
                {
                    canBePressed = false;

                    GameManager.instance.NoteMissed();
                    Vector3 effectPositionMiss = new Vector3(transform.position.x, 0.5f, transform.position.z);
                    Instantiate(missEffect, effectPositionMiss, missEffect.transform.rotation);
                }                
            }            
        }        
    }
}
