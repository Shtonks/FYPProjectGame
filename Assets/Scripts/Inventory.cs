using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<int, Item> inventoryItems;
    private int inventorySize;
    public Item blankItem;

    public Inventory() {
        inventoryItems = new Dictionary<int, Item>();
        inventorySize = 1;
        blankItem = ScriptableObject.CreateInstance("Item") as Item;
        blankItem.Init();
        inventoryItems.Add(inventorySize, blankItem);
    }

    public int AddItem(Item newItem) {
        // Check for and fill empty slot
        //Debug.Log("Inventory size: " + inventoryItems.Count);
        foreach(KeyValuePair<int, Item> slot in inventoryItems)
        {
            if(slot.Value.name == "") {
                inventoryItems[slot.Key] = newItem;
                return slot.Key;
            }
        }
        return -1;
    }

    // Make empty Item if needs be
    public void DestroyItem(int key) {
        if(inventoryItems[key].name != "") {
            inventoryItems[key] = blankItem;
        }
    }

    public bool ExpandInvSlots() {
        if(inventorySize < 4) {
            inventorySize++;
            // Item item = ScriptableObject.CreateInstance("Item") as Item;
            // item.Init();
            inventoryItems.Add(inventorySize, blankItem);
            //Debug.Log("Inventory size: " + inventorySize);
            return true;
        }
        return false;
    }

    
}
