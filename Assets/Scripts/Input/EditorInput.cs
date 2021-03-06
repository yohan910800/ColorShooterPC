using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MankindGames;

public class EditorInput : IInputModule {



    //note 
    // to activate the smartphonmode uncomment 
    //the seconde ColorSwitchCheck()
    //the "direction" and the "joystick= something something" in the updatedirecion() 
    //
    // Events
    public event Action<int> OnColorSwitch;
    public event Action<ICharacter> OnAimLock;
    public event Action<GameObject> OnTap;

    // Variables
    Vector2 direction;

    Vector2 touch0EnterPosition;
    Vector2 touch1EnterPosition;

    int loopInhibiter;

    float edgeCheckP0;
    int edgeThreshold = 100;
    float swipeTriggerDistance = 30f;
    bool edgeTouch;
    bool justOnceJoystick;

    // yohan added
    public Joystick joystick;

    public void Init() {
    }

    public void Update() {
        if (Static.GamePaused) return;
        UpdateDirection();
        ColorSwitchCheck();
        TapCheck();
    }

    public Vector2 GetDirection() {
        return direction;
    }

    // Updates the direction every frame
    void UpdateDirection() {

        if (justOnceJoystick == false)
        {
            joystick = GameObject.FindObjectOfType<Joystick>();//tmp dosen't work on the init

            justOnceJoystick = true;                                                           //}
        }
        direction = new Vector2(joystick.Horizontal, joystick.Vertical);//yohan added
            
    }

    // Checks if the user is changing the color and triggers the OnColorSwitch event if true
    void ColorSwitchCheck()
    {
        if (Input.GetKeyDown("space") && OnColorSwitch != null)
        {
            OnColorSwitch(1);
        }
    }

    // Checks for selections and triggers respective events
    void TapCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider != null)
            {
                // Trigger OnTap
                GameObject gObj = rayHit.collider.gameObject;
                if (OnTap != null) OnTap(gObj);
                // Trigger OnAimLock
                ICharacter character = gObj.GetComponent<ICharacter>();
                if (character != null && OnAimLock != null)
                {
                    OnAimLock(character);
                }
            }
        }
    }
    public void ButtonDown()
    {
        if (OnColorSwitch != null) OnColorSwitch(-1);
    }

    void EdgeSwipeCheck()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < edgeThreshold || touch.position.x > Screen.width - edgeThreshold)
                    {
                        edgeTouch = true;
                        edgeCheckP0 = touch.position.x;
                    }
                    break;
                case TouchPhase.Moved:
                    if (edgeTouch && Mathf.Abs(edgeCheckP0 - touch.position.x) >= swipeTriggerDistance)
                    {
                        edgeTouch = false;
                        int dir = edgeCheckP0 > Screen.width / 2 ? -1 : 1;
                        if (OnColorSwitch != null) OnColorSwitch(dir);
                    }
                    break;
                case TouchPhase.Ended:
                    edgeTouch = false;
                    break;
            }
        }
        return;
    }
}