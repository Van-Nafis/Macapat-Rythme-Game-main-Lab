using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    public Button button;

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        Vector3 clickPosition = Input.mousePosition;
        float clickTime = Time.time;

        Debug.Log("Button clicked at position: " + clickPosition + " at time: " + clickTime);
    }
}
