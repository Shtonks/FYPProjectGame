using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    private Transform questTrackerTemplate;
    private Transform questTrackerTransform;

    private void Awake() {
        questTrackerTemplate = transform.Find("QuestTrackerTemplate");
        questTrackerTemplate.gameObject.SetActive(false);
    }

    public void CreateQuestTracker(string title, string desc, int posIndex) {
        questTrackerTransform = Instantiate(questTrackerTemplate, gameObject.transform);
        questTrackerTransform.gameObject.SetActive(true);
        RectTransform questTrackerRectTransform = questTrackerTransform.GetComponent<RectTransform>();

        float edgeOffset = 20f;

        float Xloc = Screen.width / 2 - questTrackerRectTransform.sizeDelta.x / 2;
        float Yloc = Screen.height / 2 - questTrackerRectTransform.sizeDelta.y / 2;

        questTrackerRectTransform.anchoredPosition = new Vector2(Xloc - edgeOffset, (Yloc - edgeOffset) * posIndex);

        questTrackerTransform.Find("QuestTitle").GetComponent<TextMeshProUGUI>().SetText(title);
        questTrackerTransform.Find("QuestDesc").GetComponent<TextMeshProUGUI>().SetText(desc);
    }

    public void ActivateTracker(Quest quest) {
        CreateQuestTracker(quest.title, quest.desc, 0);
    }

    public void DeactivateTracker() {
        Destroy(questTrackerTransform.gameObject);
    }
}