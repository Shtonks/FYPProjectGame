using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteraction : GenericShopInteraction
{
    public static ShopInteraction instance { get; private set; }

    void Awake()
    {
        // This is essentially ensuring that this is a singleton class
        if(instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    [HideInInspector]
    public Shop shopInfo;

    private int currentVisibleQuest;
    public Button contractSelect;
    public Button contractAbandon;

    // Quest window elements
    public GameObject questWindow;
    public TMP_Text txtTitle;
    public TMP_Text txtShardReward;

    private void Start() {
        contractAbandon.interactable = false;
        currentVisibleQuest = -1;
    }

    private void OnDisable() {
        questWindow.SetActive(false);
        //Debug.Log("DEACTIVATING");
    }

    public void CycleQuestWindow() {

        currentVisibleQuest++;
        if(currentVisibleQuest >= shopInfo.numOfQuests) {
            currentVisibleQuest = 0;
        }
        Debug.Log("Current Vis Quest: " + currentVisibleQuest);

        questWindow.SetActive(true);
        txtTitle.text = shopInfo.quests[currentVisibleQuest].title.ToString();
        txtShardReward.text = shopInfo.quests[currentVisibleQuest].shardReward.ToString();
    }

    public void AcceptQuest() {
        questWindow.SetActive(false);
        pb.quests.Add(shopInfo.quests[currentVisibleQuest]);
        GameManager.gameManager.questTracker.ActivateTracker(shopInfo.quests[currentVisibleQuest]);
        shopInfo.GenNewQuests();
        contractSelect.interactable = false;
        contractAbandon.interactable = true;
    }

    public void AbandonQuest() {
        // Shards penalty of -50% what you would have got
        pb.shards -= shopInfo.quests[currentVisibleQuest].shardReward / 2;
        pb.quests.Remove(shopInfo.quests[currentVisibleQuest]);
        GameManager.gameManager.questTracker.DeactivateTracker();
        contractSelect.interactable = true;
        contractAbandon.interactable = false;
    }

    public void QuestComplete() {
        contractSelect.interactable = true;
        contractAbandon.interactable = false;
    }
}
