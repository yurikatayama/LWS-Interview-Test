using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider))]
public class TeleportersController : MonoBehaviour {

    private GameObject player, pfcam;
    private GameObject targetTeleport, thisTeleport;
    [SerializeField] private string playerName, cameraName, telName, targetName;
    [SerializeField] private Vector3 directionFactor;

    private void Start () {
        player = GameObject.Find (playerName);
        pfcam = GameObject.Find (cameraName);
        GetTeleportsNames ();
    }

    private void GetTeleportsNames () {
        thisTeleport = this.gameObject;

        telName = thisTeleport.name;
        targetName = telName.Substring (0, telName.Length - 3);
        targetName += telName.Substring (telName.Length - 3, 3).Equals ("Ins") ? "Out" : "Ins";

        targetTeleport = GameObject.Find (targetName);
    }

    private void Teleport () {
        player.transform.position = targetTeleport.transform.position + directionFactor;
        pfcam.transform.position = targetTeleport.transform.position + directionFactor;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag ("Player")) {
            Teleport ();
        }
    }

}