using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    private TouchScreen touchScreen;

    private void Awake()
    {
        touchScreen = new TouchScreen();
    }

    private void OnEnable()
    {
        touchScreen.Enable();
    }

    private void OnDisable()
    {
        touchScreen.Disable();
    }
    private void Start()
    {
        touchScreen.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchScreen.Touch.TouchPress.canceled += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started" + touchScreen.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(touchScreen.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Ended" + touchScreen.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnEndTouch != null) OnEndTouch(touchScreen.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);

    }
}
