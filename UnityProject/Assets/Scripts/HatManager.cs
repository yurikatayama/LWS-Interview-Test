using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour {
    [SerializeField] private Animator anim;
    [ReadOnly] public int hatIndex = 0;
    [SerializeField] private InventoryManager invManager; // reference to Inventory Manager in Player
    [SerializeField] public ItemList hatListObject; // Reference to Object that contain all Hats in game
    [SerializeField] public List<Item> hatList; // list of Hats player can wear

    private void Start () {
        anim = GetComponent<Animator> ();
        hatList.Add (hatListObject.items[0]);
        SetInventoryItensIntoHatList ();
        ChangeHatOutfit (hatList[0]);
    }

    private void Update () {
       // HatChangerDebug ();
    }

    public void SetInventoryItensIntoHatList () {
        Item item = new Item ();
        InventoryItem invItem;
        hatList.Clear ();
        hatList.Add (hatListObject.items[0]);
        for (int i = 0; i < invManager.inventoryItem.Count; i++) {
            invItem = invManager.inventoryItem[i];
            for (int j = 0; j < hatListObject.items.Count; j++) {
                item = hatListObject.items[j];
                if (item.ID == invItem.ID) {
                    hatList.Add (item);
                    print ("Hat: " + hatListObject.items[j].ID + " added");
                    break;
                }
            }
        }
    }

    public void ChangeHatOutfit (Item hat) {
        anim.runtimeAnimatorController = hat.animator;
    }

    public void ChangeHat (int i) {
        hatIndex += i;
        if (hatIndex == hatList.Count) hatIndex = 0;
        else if (hatIndex < 0) hatIndex = hatList.Count - 1;
        ChangeHatOutfit (hatList[hatIndex]);
    }

    void HatChangerDebug () {
        if (Input.GetKeyDown (KeyCode.C) && hatIndex < hatList.Count - 1) {
            hatIndex += 1;
        }
        if (Input.GetKeyDown (KeyCode.V) && hatIndex > 0) {
            hatIndex -= 1;
        }
        if (Input.GetKeyDown (KeyCode.Q)) {
            SetInventoryItensIntoHatList ();
        }
        if (Input.GetKeyDown (KeyCode.Return)) {
            ChangeHatOutfit (hatList[hatIndex]);
        }
    }
}