using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtManager : MonoBehaviour {
    [SerializeField] private Animator anim;
    public int shirtIndex = 0;
    [SerializeField] private InventoryManager invManager;
    [SerializeField] public ItemList shirtListObject;
    [SerializeField] public List<Item> shirtList;

    private void Start () {
        anim = GetComponent<Animator> ();
        shirtList.Add (shirtListObject.items[0]);
        SetInventoryItensIntoShirtList ();
        ChangeShirtOutfit (shirtList[0]);
    }

    private void Update () {
        //ShirtChangerDebug ();
    }

    public void SetInventoryItensIntoShirtList () {
        InventoryItem invItem;
        Item item = new Item ();
        shirtList.Clear ();
        shirtList.Add (shirtListObject.items[0]);
        for (int i = 0; i < invManager.inventoryItem.Count; i++) {
            invItem = invManager.inventoryItem[i];
            for (int j = 0; j < shirtListObject.items.Count; j++) {
                item = shirtListObject.items[j];
                if (item.ID == invItem.ID) {
                    shirtList.Add (item);
                    print ("Shirt: " + shirtListObject.items[j].ID + " added");
                    break;
                }
            }
        }
    }

    public void ChangeShirtOutfit (Item shirt) {
        anim.runtimeAnimatorController = shirt.animator;
    }

    public void ChangeShirt (int i) {
        shirtIndex += i;
        if (shirtIndex == shirtList.Count) shirtIndex = 0;
        else if (shirtIndex < 0) shirtIndex = shirtList.Count - 1;
        ChangeShirtOutfit (shirtList[shirtIndex]);
    }

    private void ShirtChangerDebug () {
        if (Input.GetKeyDown (KeyCode.Z) && shirtIndex < shirtList.Count - 1) {
            shirtIndex += 1;
        }
        if (Input.GetKeyDown (KeyCode.X) && shirtIndex > 0) {
            shirtIndex -= 1;
        }
        if (Input.GetKeyDown (KeyCode.Q)) {
            SetInventoryItensIntoShirtList ();
        }
        if (Input.GetKeyDown (KeyCode.Return)) {
            ChangeShirtOutfit (shirtList[shirtIndex]);
        }
    }
}