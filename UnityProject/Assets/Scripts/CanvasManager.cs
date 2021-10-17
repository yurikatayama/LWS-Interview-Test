using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    [SerializeField] private Transform shopKeeper, player;
    [SerializeField] private GameObject shopDialog, shopList, shop, dresser, controls;
    [SerializeField] private Image shirtEquipment, hatEquipment;
    [SerializeField] public HatManager hatMan;
    [SerializeField] public ShirtManager shirtMan;
    [SerializeField][ReadOnly] float distance;

    private bool CheckDistance () {
        distance = Vector2.Distance (shopKeeper.position, player.position);
        return distance < 2;
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Tab)) ToggleControls ();
        if (CheckDistance ()) {
            shop.SetActive (true);
            if (Input.GetKeyDown (KeyCode.E)) {
                if (dresser.activeInHierarchy) ToggleDresser ();
                print (CheckDistance ());
                if (shopDialog.activeInHierarchy) shopList.SetActive (true);
                else shopDialog.SetActive (true);
            }
        } else {
            shopDialog.SetActive (false);
            shopList.SetActive (false);
            shop.SetActive (false);
        }
        shirtEquipment.sprite = shirtMan.shirtList[shirtMan.shirtIndex].icon;
        hatEquipment.sprite = hatMan.hatList[hatMan.hatIndex].icon;
    }

    public void ToggleDresser () {
        dresser.SetActive (!(dresser.activeInHierarchy));
        print ("dresser is: " + dresser.activeInHierarchy);
    }

    public void ToggleControls () {
        controls.SetActive (!(controls.activeInHierarchy));
        print ("controls is: " + dresser.activeInHierarchy);
    }
}