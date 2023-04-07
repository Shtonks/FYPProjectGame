using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerBehaviour pb;
    
    public TMP_Text txtSpeed;
    public TMP_Text txtHealth;
    public TMP_Text txtFuel;
    public TMP_Text txtShards;

    public Image itemSlotIcon1;
    public Image itemSlotIcon2;
    public Image itemSlotIcon3;
    public Image itemSlotIcon4;

    public GameObject itemSlot1;
    public GameObject itemSlot2;
    public GameObject itemSlot3;
    public GameObject itemSlot4;

    public Slider juraRepSlider;
    public Slider nardvaalRepSlider;
    public Slider welkanRepSlider;

    private int lastSpeed;
    public int lastHealth;
    private int lastFuelLvl;
    private int lastShards;

    // public int health;

    public List<GameObject> healthStatusBar;
    public int maxHealth;

    void Start()
    {
        // health = pb.GetHealth();
        maxHealth = GameManager.gameManager.Health.MaxHealth;

        txtSpeed.text = "0" + pb.speed.ToString();
        txtFuel.text = pb.fuelLvl.ToString();
        txtShards.text = pb.shards.ToString();

        juraRepSlider.maxValue = Jura.Instance.getMaxRep();
        juraRepSlider.value = Jura.Instance.getRep();
        welkanRepSlider.maxValue = Welkan.Instance.getMaxRep();
        welkanRepSlider.value = Welkan.Instance.getRep();
        nardvaalRepSlider.maxValue = Nardvaal.Instance.getMaxRep();
        nardvaalRepSlider.value = Nardvaal.Instance.getRep();
        Debug.Log("Max val:" + Nardvaal.Instance.getMaxRep() + "Curr val: " + Nardvaal.Instance.getRep());
    }

    void Update()
    {
        //TO DO: I'll have to deal with negative speed soon to
        if(lastSpeed != pb.speed) {
            if(pb.speed < 10) {
                txtSpeed.text = "0" + pb.speed.ToString();
            }else {
                txtSpeed.text = pb.speed.ToString();
            }
        }

        if (lastHealth != pb.GetHealth()) {
            SetHealthStatusBar(pb.GetHealth());
            lastHealth = pb.GetHealth();
        }

        if (lastFuelLvl != pb.fuelLvl) {
            txtFuel.text = pb.fuelLvl.ToString();
        }

        if (lastShards != pb.shards) {
            txtShards.text = pb.shards.ToString();
        }
        
    }

    private void SetHealthStatusBar(int currentHealth) {
        for (int i = 0; i < maxHealth; i++)
        {
            if(i < currentHealth) {
                healthStatusBar[i].SetActive(true);
            } else {
                healthStatusBar[i].SetActive(false);
            }
        }
    }

    public void UpdateItemSlotIcon(int n, Item item) {
        switch(n)
        {
            case 1:
                Debug.Log("Item name: "+ item.name);
                itemSlotIcon1.sprite = item.itemSprite;
                break;
            case 2:
                itemSlotIcon2.sprite = item.itemSprite;
                break;
            case 3:
                itemSlotIcon3.sprite = item.itemSprite;
                break;
            case 4:
                itemSlotIcon4.sprite = item.itemSprite;
                break;
            default:
                throw new System.ArgumentException("Invalid number");
        }
    }

    public void ActivateNewItemSlot() {
        if(!itemSlot2.activeSelf) {
            itemSlot2.SetActive(true);
            Debug.Log("Activtaed slot 2");
            return;
        } else if(!itemSlot3.activeSelf) {
            itemSlot3.SetActive(true);
            Debug.Log("Activtaed slot 3");
            return;
        } else if(!itemSlot4.activeSelf) {
            itemSlot4.SetActive(true);
            Debug.Log("Activtaed slot 4");
            return;
        } else {
            return;
        }
    }


    public void SetFactionRep(Faction fact, int rep) {
        string name = fact.getName();
        switch(name) {
            case "Jura":
                juraRepSlider.value = rep;
                break;
            case "Welkan":
                welkanRepSlider.value = rep;
                break;
            case "Nardvaal":
                nardvaalRepSlider.value = rep;
                break;
        }
    }
}
