using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteractions : MonoBehaviour
{
    public PlayerBehaviour pb;

    public int fuelPrice = 10;
    public int healPrice = 30;


    //public Button tempGibShardsBtn;
    //public Button buyBtn;

    public void BuyFuel() {
        if(pb.shards >= fuelPrice){
            pb.fuelLvl++;
            pb.shards -= fuelPrice;
        }
    }

    public void RepairDmg() {
        if(pb.GetHealth() < 8) {
            pb.Heal(1);
        }
    }
    
    public void QuestSelected(Quest quest) {
        
    }
}
