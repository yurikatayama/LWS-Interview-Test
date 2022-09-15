using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardDetector : MonoBehaviour {

    public delegate void ActionDelegate ();
    public ActionDelegate upAxisDelegate, leftAxisDelegate, downAxisDelegate, rightAxisDelegate;
    public ActionDelegate upButtonDelegate, leftButtonDelegate, downButtonDelegate, rightButtonDelegate;
    public ActionDelegate interactDelegate;

    // Axis floats
    [Header ("Axis Floats")]
    [SerializeField][ReadOnly] public float horizontalAxis;
    [SerializeField][ReadOnly] public float verticalAxis;

    // Input bools
    [Header ("Input Bools")]
    [SerializeField][ReadOnly] public bool upButton;
    [SerializeField][ReadOnly] public bool downButton;
    [SerializeField][ReadOnly] public bool leftButton;
    [SerializeField][ReadOnly] public bool rightButton;
    [SerializeField][ReadOnly] public bool interactButton;

    // Custom Input System
    [SerializeField][ReadOnly] public bool isDetectingKey;
    [SerializeField][ReadOnly] public KeyCode newKeyCode;

    /// <summary>
    /// This method will set the buttons and axis used in the delegates.
    /// It could be updated to a Custom Input System using DetectInput and SetInput.
    /// </summary>
    void SetAxisAndButtons () {
        horizontalAxis = Input.GetAxisRaw ("Horizontal");
        verticalAxis = Input.GetAxisRaw ("Vertical");

        upButton = Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W);
        downButton = Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S);
        leftButton = Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A);
        rightButton = Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D);
        // Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return) || 
        interactButton = Input.GetKeyDown (KeyCode.E);
    }

    void PlayDelegate () {
        if (verticalAxis > 0 && upAxisDelegate != null) upAxisDelegate ();
        if (verticalAxis < 0 && upAxisDelegate != null) downAxisDelegate ();
        if (horizontalAxis > 0 && upAxisDelegate != null) rightAxisDelegate ();
        if (horizontalAxis < 0 && upAxisDelegate != null) leftAxisDelegate ();

        if (upButton && upAxisDelegate != null) upButtonDelegate ();
        if (downButton && upAxisDelegate != null) downButtonDelegate ();
        if (rightButton && upAxisDelegate != null) rightButtonDelegate ();
        if (leftButton && upAxisDelegate != null) leftButtonDelegate ();

        if (interactButton && upAxisDelegate != null) interactDelegate ();
    }

    // ##############################################################################################
    // ##############################################################################################

    /// <summary>
    /// It will detect the next Input activated (as boolean) and store it on kCode. 
    /// Must be used as an key detector to remap keybindings and create a customizable input system.
    /// </summary>
    public void DetectInput () {
        print ("Setting custom key");
        foreach (KeyCode pressedkey in System.Enum.GetValues (typeof (KeyCode))) {
            if (Input.GetKey (pressedkey)) {
                if (pressedkey != KeyCode.Escape) {
                    newKeyCode = pressedkey;
                    isDetectingKey = false;
                    print ("Custom key stored: " + newKeyCode);
                }
            }
        }
    }

    /// <summary>
    /// Initialize the Input Detection system to customize keybindings by pressing Escape.
    /// Would be better to change this Escape trigger to a UI function, but it will work
    /// this way for now. 
    /// </summary>
    public void SetInput () {
        if (Input.GetKeyDown (KeyCode.Escape)) isDetectingKey = !isDetectingKey;
        if (isDetectingKey) DetectInput ();
        // if (Input.GetKeyDown (newKeyCode)) print ("Custom key worked");
    }

    // ##############################################################################################
    // ##############################################################################################
    private void Update () {
        SetInput ();
        SetAxisAndButtons ();
        PlayDelegate ();
    }

}