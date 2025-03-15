using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectDebug : MonoBehaviour
{
    public bool canBePressedDe;

    public KeyCode keyToPressDe;

    public GameObject hitEffectDe, goodEffectDe, perfectEffectDe, missEffectDe;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(keyToPressDe))
        {
            if (canBePressedDe)
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

    public void ButtonPressed()
    {
        if (Input.GetKeyDown(keyToPressDe))
        {
            if (canBePressedDe)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffectDe, transform.position, hitEffectDe.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffectDe, transform.position, goodEffectDe.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffectDe, transform.position, perfectEffectDe.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressedDe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.tag == "Activator")
            {
                canBePressedDe = false;

                GameManager.instance.NoteMissed();
                Instantiate(missEffectDe, transform.position, missEffectDe.transform.rotation);
            }
        }
    }
}
