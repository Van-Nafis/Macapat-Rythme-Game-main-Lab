using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpGatra : MonoBehaviour
{
    [SerializeField] float posisiX, posisiY;
    public GameObject popUpTextParent;
    public Text popUpText;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = MusicTrack.instance.guruGatra.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*PerbesarCollider();// Jangan di taruh di update*/
    }

    private void OnTriggerEnter2D(Collider2D greenBarOverlap)
    {
        Text instantiatePopUpGatra = Instantiate(popUpText, popUpTextParent.transform, false);
        instantiatePopUpGatra.text = MusicTrack.instance.guruGatra[i].GuruWilangan;
        RectTransform rectPopUp = instantiatePopUpGatra.GetComponent<RectTransform>();
        rectPopUp.anchoredPosition = new Vector2(posisiX, posisiY);

        i = --i;

        Destroy(instantiatePopUpGatra, 3.5f);

    }

    private void PerbesarCollider()
    {
        RectTransform rect = GetComponent<RectTransform>();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if (rect != null && collider != null)
        {
            collider.size = rect.rect.size;
            collider.offset = rect.rect.center;
            Physics2D.SyncTransforms(); // hanya saat perlu
        }
    }

}
