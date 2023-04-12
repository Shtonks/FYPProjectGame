using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeOfGame : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            GameManager.gameManager.GameOverScreen("voidEsc", null);
        }
    }
}
