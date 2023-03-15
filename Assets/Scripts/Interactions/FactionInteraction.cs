using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionInteraction : GenericShopInteraction
{
    public Faction faction;

    private void Start() {
        if(gameObject.name == "JuraUI") {
            faction = Jura.Instance;
        } else if(gameObject.name == "NardvaalUI") {
            faction = Nardvaal.Instance;
        } else {
            faction = Welkan.Instance;
        }
    }

    public void DeliverItem() {
        foreach (Quest q in pb.quests) {                                // For every quest
            if (q.questGoal.GetType() == typeof(DeliveryGoal)) {        // Check the goal type
                DeliveryGoal delGoal = ((DeliveryGoal)q.questGoal);     // Cast the goal to DeliveryGoal
                if(delGoal.faction == this.faction) {                   // Check if is right faction
                    foreach(Item item in pb.items) {                    // For all player items 
                        if(item == delGoal.itemWanted) {                // Check if player has wanted item
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
}