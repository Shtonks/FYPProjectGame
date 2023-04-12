using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenericShopInteraction : MonoBehaviour
{
    //public QuestTracker questTracker;

    public PlayerBehaviour pb;

    public int fuelPrice = 10;
    public int healPrice = 30;

    public int maxSpeedPrice = 10;
    public int fuelCapPrice = 30;
    public int accelPrice = 10;
    public int shieldRechPrice = 30;
    public int shieldDurPrice = 10;
    public int invExpandPrice = 1000;

    public TMP_Text maxSpeedPriceTxt;
    public TMP_Text fuelCapPriceTxt;
    public TMP_Text accelPriceTxt;
    public TMP_Text shieldRechPriceTxt;
    public TMP_Text shieldDurPriceTxt;
    public TMP_Text invExpandPriceTxt;

    private void Update() {
        maxSpeedPriceTxt.text = maxSpeedPrice.ToString();
        fuelCapPriceTxt.text = fuelCapPrice.ToString();
        accelPriceTxt.text = accelPrice.ToString();
        shieldRechPriceTxt.text = shieldRechPrice.ToString();
        shieldRechPriceTxt.text = shieldRechPrice.ToString();
        invExpandPriceTxt.text = invExpandPrice.ToString();
    }


    public void BuyFuel() {
        if(pb.shards >= fuelPrice && pb.fuelLvl < pb.maxFuelLvl){
            pb.fuelLvl++;
            pb.shards -= fuelPrice;
        }
    }

    public void HealDmg() {
        if(pb.GetHealth() < 8) {
            pb.Heal(1);
        }
    }

                // TO DELETE
    //hjvkjk
    // dfhvj;private void OnAnimatorIK(int layerIndex) {
    //     ocvdjfopv
    //     jvcfdsiovo
    //     cjiosdpjfv
    //     cojsdpf
    // }
    public void FreeMoneyDebug() {
        pb.shards += 5000;
    }

    public void InstantQuestComp() {
        if(pb.quests != null){
            //pb.QuestComplete(pb.quests[0]);
        }
    }

    //Upgrades

    public void MaxSpeedInc() {
        if(pb.shards >= maxSpeedPrice){
            pb.maxShipSpeed += 5.0f;
            pb.shards -= maxSpeedPrice;
            maxSpeedPrice += (int)(maxSpeedPrice * 0.5f);
        }
    }

    public void FuelCapInc() {
        if(pb.shards >= fuelCapPrice){
            pb.maxFuelLvl += 2;
            pb.shards -= fuelCapPrice;
            fuelCapPrice += (int)(fuelCapPrice * 0.25f);
        }
    }

    public void AccelInc() {
        if(pb.shards >= accelPrice){
            pb.accelFactor += 5;
            pb.shards -= accelPrice;
            accelPrice += (int)(accelPrice * 0.25f);
        }
    }

    public void ShieldRechInc() {
        if(pb.shards >= shieldRechPrice){
            pb.shieldRechargeInterval *= 0.25f;
            pb.shards -= shieldRechPrice;
            shieldRechPrice += (int)(shieldRechPrice * 0.25f);
        }
    }

    public void ShieldDurInc() {
        if(pb.shards >= shieldDurPrice){
            pb.shieldRechargeInterval += pb.shieldRechargeInterval * 0.25f;
            pb.shards -= shieldDurPrice;
            shieldDurPrice += (int)(shieldDurPrice * 0.25f);
        }
    }

    public void InventorySlotInc() {
        if(pb.shards >= invExpandPrice) {
            if(pb.inventory.ExpandInvSlots()) {
                pb.playerUIManager.ActivateNewItemSlot();
                pb.shards -= invExpandPrice;
                invExpandPrice *= 2;
            }
        }
    }
}
