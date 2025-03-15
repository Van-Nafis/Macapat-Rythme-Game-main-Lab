using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteObjectArchive : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public string penanda;

    public Button btn;

    public bool isPressed = false;

    public bool isMouseUp = true;

    public GameManager GM;



    // Start is called before the first frame update
    void Start()
    {
        OnMouseUp();
        OnMouseDown();
        /*btn.onClick.AddListener(btnClicked)*/
        ;
    }

    // Update is called once per frame
    void Update()
    {
        // Deteksi jika tombol yang terkait ditekan
        if (Input.GetKeyDown(KeyCode.Mouse0) && canBePressed)
        {
            StartCoroutine(HoldCombo());
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopCoroutine(HoldCombo());
            isPressed = false;
        }


        /*if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }*/
    }

    public void btnClicked()
    {
        if (canBePressed)
        {
            gameObject.SetActive(false);

            //GameManager.instance.NoteHit();

            if (Mathf.Abs(transform.position.y) > 0.25)
            {
                Debug.Log("Hit");
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            else if (Mathf.Abs(transform.position.y) > 0.05f)
            {
                Debug.Log("Good");
                GameManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            else if (Mathf.Abs(transform.position.y) >= 0)
            {
                Debug.Log("Perfect");
                GameManager.instance.PerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            }
        }

    }

    // IEnumerator coba
    private IEnumerator HoldCombo()
    {
        isPressed = true;
        while (isPressed && canBePressed)
        {
            yield return new WaitForSeconds(2f); // Waktu jeda selama hold (2 detik)
            GameManager.instance.ComboHit();
            Debug.Log("Combo Berhasil");

            // Tambahkan efek kombo atau visual jika diperlukan
            Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
        }
    }
    // Akhir dari IEnumerator coba


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == penanda)
        {
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {

            if (collision.tag == penanda)
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }

    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        isMouseUp = true;
        canBePressed = false;
        /*gameObject.SetActive(false);*/
    }

    private void OnMouseDown()
    {
        if (canBePressed)
        {
            Debug.Log("OnMouseDown");
            isMouseUp = false;
            canBePressed = true;
        }
    }

    public void btnCombo()
    {
        // if (!isMouseUp || canBePressed)
        if (/*transform.position.y <= 0 || */canBePressed)
        {
            Debug.Log("Combo Berhasil");
            GameManager.instance.ComboHit();
            Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);

            // Mengambil komponen Image dan mengubahnya agar tidak terlihat
            Image imageComponent = gameObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = false; // Menyembunyikan gambar
            }
        }
        else if (transform.position.y < 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnLeftHold()
    {
        while (isPressed == true)
        {

        }
    }
    /*public void startCombo()
    {
        StartCoroutine(ComboRoutine());
    }

    public IEnumerator ComboRoutine()
    {
        // Loop yang akan terus berjalan
        while (canBePressed == true)
        {
            Debug.Log("Combo Berhasil");
            GameManager.instance.ComboHit();
            Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            

            // Tunggu sebentar sebelum loop berlanjut lagi
            yield return new WaitForSeconds(0.5f); // Waktu jeda tiap loop (0.5 detik sebagai contoh)
        }

        // Setelah looping selesai, nonaktifkan game object
        gameObject.SetActive(false);
    }*/

    public void clickBlock()
    {
        if (gameObject.transform.position.y >= 0)
        {
            canBePressed = false;
        }
    }

    /*public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            canBePressed = true;
            
        }
    }*/
    /*public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }*/
}
