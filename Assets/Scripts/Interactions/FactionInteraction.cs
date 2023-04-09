using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionInteraction : GenericShopInteraction
{
    public Faction faction;
    public Image vendorImg;

    private void Start() {
        if(gameObject.name == "JuraUI") {
            faction = Jura.Instance;
            vendorImg.sprite = Resources.Load<Sprite>("/Sprites/Shop/Vendors/JuraVendor");
        } else if(gameObject.name == "NardvaalUI") {
            faction = Nardvaal.Instance;
            vendorImg.sprite = Resources.Load<Sprite>("/Sprites/Shop/Vendors/NardvaalVendor");
        } else {
            faction = Welkan.Instance;
            vendorImg.sprite = Resources.Load<Sprite>("/Sprites/Shop/Vendors/WelkanVendor");
        }
    }

    public void DeliverItem() {
        foreach (Quest q in pb.quests) {                                // For every quest
            if (q.questGoal.GetType() == typeof(DeliveryGoal)) {        // Check the goal type
                DeliveryGoal delGoal = ((DeliveryGoal)q.questGoal);     // Cast the goal to DeliveryGoal
                if(delGoal.faction == this.faction) {                   // Check if is right faction
                    foreach(KeyValuePair<int, Item> slot in pb.inventory.inventoryItems) {
                        if(slot.Value == delGoal.itemWanted) {
                            pb.QuestComplete(q);
                            Debug.Log("DeliveredItem!");
                            return;
                        }
                    }
                    Debug.Log("No item to deliver found");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            pb.playerUIManager.UpdateMapFaction(gameObject.transform.position, faction);
        }
    }
}
