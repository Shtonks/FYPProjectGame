using System.Collections.Generic;
using UnityEngine;

public class DiscoveredPOI : MonoBehaviour
{
    public PlayerBehaviour player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Player") {
        //     Debug.Log("Inside Coll");
        //     foreach (Quest q in player.quests) {
        //         if (q.questGoal.goalType == GoalType.Explore) // And if currentLocation == desiredLocation
        //             q.questGoal.LocationDiscovered();
        //             if(q.questGoal.CheckComplete()) 
        //                 player.QuestComplete(q);
        //     }
        // }
        
    }
}
