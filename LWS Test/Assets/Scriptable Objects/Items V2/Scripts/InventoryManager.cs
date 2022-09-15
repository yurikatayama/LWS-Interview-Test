using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public List<InventoryItem> inventoryItem;

    private void Update () {
        AddItemsDebug ();
    }

    public void AddItemToInventory (string addedID) {
        InventoryItem item = new InventoryItem ();
        item.ID = addedID;
        inventoryItem.Add (item);
    }

    public void RemoveItemFromInventory (string removedID) {
        InventoryItem item;
        for (int i = 0; i < inventoryItem.Count; i++) {
            item = inventoryItem[i];
            if (item.ID == removedID) {
                inventoryItem.RemoveAt (i);
                break;
            }
        }
    }

    public void PrintListOfOutfits () {
        InventoryItem outfit;
        for (int i = 0; i < inventoryItem.Count; i++) {
            outfit = inventoryItem[i];
            print ("Item: " + outfit.ID);
        }
    }

    void AddItemsDebug () {
        if (Input.GetKeyDown (KeyCode.R)) {
            for (int i = 0; i < 1000; i++) {
                AddItemToInventory ("HC001ID001");
                AddItemToInventory ("HC001ID002");
                AddItemToInventory ("HC001ID003");
                AddItemToInventory ("SC001ID001");
                AddItemToInventory ("SC001ID002");
                AddItemToInventory ("SC001ID003");
            }
        }
        if (Input.GetKeyDown (KeyCode.F)) {
            for (int i = 0; i < 50; i++) {
                AddItemToInventory ("HC001ID001");
                AddItemToInventory ("HC001ID002");
                AddItemToInventory ("HC001ID003");
                AddItemToInventory ("SC001ID001");
                AddItemToInventory ("SC001ID002");
                AddItemToInventory ("SC001ID003");
            }
        }
        if (Input.GetKeyDown (KeyCode.T)) AddItemToInventory ("HC001ID001");
        if (Input.GetKeyDown (KeyCode.Y)) AddItemToInventory ("HC001ID002");
        if (Input.GetKeyDown (KeyCode.U)) AddItemToInventory ("HC001ID003");

        if (Input.GetKeyDown (KeyCode.I)) AddItemToInventory ("SC001ID001");
        if (Input.GetKeyDown (KeyCode.O)) AddItemToInventory ("SC001ID002");
        if (Input.GetKeyDown (KeyCode.P)) AddItemToInventory ("SC001ID003");
        if (Input.GetKeyDown (KeyCode.G)) RemoveItemFromInventory ("HC001ID001");
        if (Input.GetKeyDown (KeyCode.H)) RemoveItemFromInventory ("HC001ID002");
        if (Input.GetKeyDown (KeyCode.J)) RemoveItemFromInventory ("HC001ID003");
        if (Input.GetKeyDown (KeyCode.K)) RemoveItemFromInventory ("SC001ID001");
        if (Input.GetKeyDown (KeyCode.L)) RemoveItemFromInventory ("SC001ID002");
        if (Input.GetKeyDown (KeyCode.M)) RemoveItemFromInventory ("SC001ID003");

        // if (Input.GetKeyDown (KeyCode.Return)) {
        //     PrintListOfOutfits ();
        // }
    }

}