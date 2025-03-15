using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBelajar : MonoBehaviour
{
    public int statAwal = 0;
    public float moveStep = 630f;

    public GameObject btnRight, btnLeft;
    public RectTransform uiElement;
    public Transform parentObj;
    public List<GameObject> childList = new List<GameObject>();

    public float moveDistance = 50f;
    public float moveSpeed = 5f;

    private void Start()
    {
        if (parentObj != null)
        {
            foreach (Transform child in parentObj)
            {
                childList.Add(child.gameObject);
            }
        }
    }

    private void Update()
    {
        if (statAwal == 0)
        {
            foreach (GameObject child in childList)
            {
                child.SetActive(false);
            }

            childList[0].SetActive(true);
            btnLeft.SetActive(false);
        }

        else if (statAwal == 10)
        {
            foreach (GameObject child in childList)
            {
                child.SetActive(false);
            }

            childList[10].SetActive(true);
            btnRight.SetActive(false);
        }

        else
        {
            foreach (GameObject child in childList)
            {
                child.SetActive(false);
                childList[statAwal].SetActive(true);
            }

            btnRight.SetActive(true);
            btnLeft.SetActive(true);
        }
    }

    public void MoveRight()
    {
        if (statAwal < 10)
        {
            
            statAwal += 1;
            /*posTransform(statAwal);*/
            /*UpdatePosition();*/
            uiElement.localPosition += new Vector3(-moveStep, 0, 0);
        }        
        Debug.Log("stat awal = " + statAwal);
    }

    public void MoveLeft()
    {
        if (statAwal > 0)
        {
            
            statAwal -= 1;
            /*posTransform(statAwal);*/
            /*UpdatePosition();*/
            uiElement.localPosition += new Vector3(moveStep, 0, 0);
        }  
        Debug.Log("stat awal = " + statAwal);
    }

    /*private void posTransform(int i)
    {
        transform.position = (Vector3)new Vector2(-630f * i, 0);
        Debug.Log("i: " + i + " | Posisi X: " + transform.position.x);

    }

    private void UpdatePosition()
    {
        // Menggeser objek ke kanan atau kiri berdasarkan statAwal
        transform.position = new Vector3(statAwal * moveStep, transform.position.y, transform.position.z);
        Debug.Log("Stat: " + statAwal + " | Posisi X: " + transform.position.x);
    }

    public void MoveRightSmooth()
    {
        StartCoroutine(MoveUI(new Vector2(uiElement.anchoredPosition.x + moveDistance, uiElement.anchoredPosition.y)));
    }

    IEnumerator MoveUI(Vector2 targetPos)
    {
        while (Vector2.Distance(uiElement.anchoredPosition, targetPos) > 0.1f)
        {
            uiElement.anchoredPosition = Vector2.Lerp(uiElement.anchoredPosition, targetPos, Time.deltaTime * moveSpeed);
            yield return null;
        }
        uiElement.anchoredPosition = targetPos; // Pastikan sampai target
    }*/
}
