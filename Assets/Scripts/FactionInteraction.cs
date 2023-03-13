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
        if(pb.quests[0].deliveryFact == faction) {
            // Proper way if multi quests allowed
            // foreach (Quest q in playerBehaviour.quests) {
            //     if (q.questGoal.GetType() == typeof(DeliveryGoal)) {
            //         if(islandItem == q.item) {
            //             q.questGoal.Success();
            //         }
            //     }
            // }
            foreach(Item item in pb.items) {
                if(item == pb.quests[0].item) {
                    pb.quests[0].questGoal.Success();
                }
            }

            if(pb.quests[0].questGoal.CheckComplete()) {
                pb.QuestComplete(pb.quests[0]);
            }
        } else {
            Debug.Log("We do not need these supplies");
        }
    }
}
