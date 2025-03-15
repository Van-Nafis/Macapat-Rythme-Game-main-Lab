using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    [SerializeField] Sprite defaultImage;
    [SerializeField] Sprite pressedImage;

    [SerializeField] KeyCode keyToPress;
    /*public InputAction Touchscreen;*/

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }

        

        /*if (InputAction.GetTouch(Touchscreen))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetTouch(Touchscreen))
        {
            theSR.sprite = defaultImage;
        }*/
    }
}
