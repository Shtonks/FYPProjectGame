using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPrompt : MonoBehaviour
{
    //public GameObject shopUI;
    public GameObject shopUIPrompt;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            shopUIPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            shopUIPrompt.SetActive(false);
        }
    }
}
