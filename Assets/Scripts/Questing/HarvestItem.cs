using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarvestItem : MonoBehaviour
{
    public Item islandItem;
    private bool isDiscovered;
    public GameObject harvestItemPrompt;
    public PlayerBehaviour pb;

    private bool shopColl;

    private void Start() {
        shopColl = false;
        isDiscovered = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            harvestItemPrompt.GetComponentInChildren<TextMeshProUGUI>().SetText("Press R to harvest " + islandItem.name);
            harvestItemPrompt.SetActive(true);
            shopColl = true;
            if(!isDiscovered) {
                OnDiscovery();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            harvestItemPrompt.SetActive(false);
            shopColl = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && shopColl) {
            pb.AddItem(islandItem);
            //Debug.Log("Item added!");
        }
    }

    private void OnDiscovery() {
        isDiscovered = true;
        pb.playerUIManager.UpdateMapPOI(transform.position, islandItem);
        //transform
    }
}
