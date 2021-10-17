using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    [SerializeField][ReadOnly] private bool opened, nearby;
    [SerializeField][ReadOnly] private float distanceToPlayer;
    private GameObject player, doorOpened, doorClosed;
    private Vector2 doorPosition;
    [SerializeField] private KeyboardDetector keyboard;

    private void Start () {
        opened = false;
        player = GameObject.Find ("PF Player");
        doorClosed = GameObject.Find ("PF Props Wooden Gate");
        doorOpened = GameObject.Find ("PF Props Wooden Gate Opened");
        doorPosition = doorClosed.transform.position;
        //keyboard = GameObject.Find ("Keyboard").GetComponent<KeyboardDetector> ();
    }

    private void Update () {
        distanceToPlayer = Vector2.Distance (doorPosition, player.transform.position);

        if (distanceToPlayer < .6f) {
            if (/*keyboard.interactButton || */Input.GetKeyDown (KeyCode.E))
                opened = !opened;
        } else {
            opened = false;
        }

        doorOpened.SetActive (opened);
        doorClosed.SetActive (!opened);
    }

}