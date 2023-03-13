using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericShopInteraction : MonoBehaviour
{
    public PlayerBehaviour pb;

    public int fuelPrice = 10;
    public int healPrice = 30;

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

    // Add more upgrades
}
