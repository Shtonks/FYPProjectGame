using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EdgeOfWorld : MonoBehaviour
{
    public PlayerBehaviour pb;
    public GameObject edgeOfWorldPrompt;
    private TextMeshProUGUI txt;
    private bool countdownTrig;
    public float editorPickedCountdown;
    private float countdown;

    private void Start() {
        countdownTrig = false;
        TextMeshProUGUI txt = edgeOfWorldPrompt.GetComponentInChildren<TextMeshProUGUI>();
        countdown = editorPickedCountdown;
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            edgeOfWorldPrompt.SetActive(true);
            countdownTrig = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            edgeOfWorldPrompt.SetActive(false);
            countdownTrig = false;
            countdown = editorPickedCountdown;
        }
    }

    private void Update() {
        if(countdownTrig) {
            if(countdown > 0){
                countdown -= Time.deltaTime;
                edgeOfWorldPrompt.GetComponentInChildren<TextMeshProUGUI>().SetText("Ship integrity will be compromised in " + countdown.ToString("0"));
            } else {
                InvokeRepeating("DmgPlayer", 0.1f, 0.5f);
                countdownTrig = false;
            }
        }
    }

    private void DmgPlayer() {
        if (pb.GetHealth() - 2 > 0) {
            pb.TakeDmg(2);
        } else {
            GameManager.gameManager.GameOverScreen("voidDeath", null);
        }
    }
}
