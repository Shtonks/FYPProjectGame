using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarvestItem : MonoBehaviour
{
    public Item islandItem;
    public GameObject harvestItemPrompt;
    public PlayerBehaviour playerBehaviour;

    private bool shopColl = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            harvestItemPrompt.GetComponentInChildren<TextMeshProUGUI>()
                .SetText("Press R to harvest " + islandItem.ToString());
            harvestItemPrompt.SetActive(true);
            shopColl = true;
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
            playerBehaviour.items.Add(islandItem);
        }
    }
}
