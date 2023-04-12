using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionInteraction : GenericShopInteraction
{
    public Faction faction;

    private void Start() {
        switch(gameObject.name) {
            case "JuraUI": 
                faction = Jura.Instance;
                Debug.Log("In jura startup");
                break;
            case "NardvaalUI":
                faction = Nardvaal.Instance;
                break;
            case "WelkanUI":
                faction = Welkan.Instance;
                break;
        }
    }

    public void DeliverItem() {
        Debug.Log("fact name: "+ faction.getName());

        if(pb.quests.Count > 0) {
            DeliveryGoal delGoal = ((DeliveryGoal)pb.quests[0].questGoal); 
            // Debug.Log("Del goal: "+ delGoal.itemWanted.name + "   " + delGoal.faction.getName());
            delGoal.DisplayAllFacts();
            if(delGoal.IsFactionFound(faction)) {
                foreach(KeyValuePair<int, Item> slot in pb.inventory.inventoryItems) {
                    if(slot.Value == delGoal.itemWanted) {
                        Debug.Log("CHOSEN FACT: "+ faction.getName());
                        pb.QuestComplete(pb.quests[0], faction);
                        pb.DestroyItem(slot.Key);
                        GameManager.gameManager.questTracker.DeactivateTracker();
                        Debug.Log("Delivered Item!");
                        return;
                    }
                    Debug.Log("Item not valid: " + slot.Value.name);
                }
            }
            Debug.Log("Wrong faction kiddo");
        }
        Debug.Log("No quest active");
    }
}
