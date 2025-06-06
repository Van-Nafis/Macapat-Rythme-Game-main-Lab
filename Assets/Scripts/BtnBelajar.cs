using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBelajar : MonoBehaviour
{
    public int statAwal = 0;
    public float moveStep = 630f;

    public GameObject btnRight, btnLeft;
    public RectTransform uiElement;
    public Transform parentObjText, parentObjImg;
    public List<GameObject> childListPenj = new List<GameObject>();
    public List<GameObject> childListImg = new List<GameObject>();

    public float moveDistance = 50f;
    public float moveSpeed = 5f;

    public MacapatPlayer macapatPlayer;

    private void Start()
    {
        if (parentObjText != null && parentObjImg != null)
        {
            foreach (Transform child in parentObjText)
            {
                childListPenj.Add(child.gameObject);
            }

            foreach (Transform child in parentObjImg)
            {
                childListImg.Add(child.gameObject);
            }
        }
    }

    private void Update()
    {
        if (statAwal == 0)
        {
            foreach (GameObject child in childListPenj)
            {
                child.SetActive(false);
            }
            foreach (GameObject child in childListImg)
            {
                child.SetActive(false);
            }

            if (parentObjText == null)
            {
                Debug.Log("parentObjText kosong");
            }

            if (parentObjImg == null)
            {
                Debug.Log("parentObjImg kosong");
            }

            childListPenj[0].SetActive(true);
            childListImg[0].SetActive(true);
            btnLeft.SetActive(false);
        }

        else if (statAwal == 10)
        {
            foreach (GameObject child in childListPenj)
            {
                child.SetActive(false);
            }
            foreach (GameObject child in childListImg)
            {
                child.SetActive(false);
            }

            childListPenj[10].SetActive(true);
            childListImg[10].SetActive(true);
            btnRight.SetActive(false);
        }

        else
        {
            foreach (GameObject child in childListPenj)
            {
                child.SetActive(false);
                childListPenj[statAwal].SetActive(true);
            }
            foreach (GameObject child in childListImg)
            {
                child.SetActive(false);
                childListImg[statAwal].SetActive(true);
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
            uiElement.localPosition += new Vector3(-moveStep, 0, 0);
            if (macapatPlayer == null) 
            {
                return;
            }
            macapatPlayer.PlayMacapatByIndex(statAwal);
            
        }
        Debug.Log("stat awal = " + statAwal);
    }

    public void MoveLeft()
    {
        if (statAwal > 0)
        {
            
            statAwal -= 1;
            uiElement.localPosition += new Vector3(moveStep, 0, 0);
            if (macapatPlayer == null)
            {
                return;
            }
            macapatPlayer.PlayMacapatByIndex(statAwal);
            
        }  
        Debug.Log("stat awal = " + statAwal);
    }
}
