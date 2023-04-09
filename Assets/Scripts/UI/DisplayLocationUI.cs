using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLocationUI : MonoBehaviour
{
    [SerializeField] private GameObject locationUI;
    [SerializeField] private GameObject locationUIPrompt;
    [SerializeField] private GameObject ship;

    private bool locColl = false;
    private bool inMenu = false;

    private Rigidbody2D shipRb;

    // Start is called before the first frame update
    void Awake()
    {
        shipRb = ship.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            locationUIPrompt.SetActive(true);
            locColl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            locationUIPrompt.SetActive(false);
            locColl = false;
        }
    }

    void Update()
    {
        // Checks if player is in range of shop and displays if so
        if(Input.GetKeyDown(KeyCode.R) && locColl) {
            //ToggleMenu();

            if(!inMenu) {
                inMenu = true;
                locationUIPrompt.SetActive(false);
                locationUI.SetActive(true);
                if(locationUI.name == "ShopUI"){
                    ShopInteraction.instance.shopInfo = gameObject.GetComponent<Shop>();
                    //Debug.Log("Successly set shop component i thinkl");
                }
            } else {
                inMenu = false;
                ship.GetComponent<TopDownShipController>().setCanMove(true);
                locationUI.SetActive(false);
            }
        }

        // Stops ship moving
        if(inMenu) {
            shipRb.velocity = Vector2.zero;
            shipRb.angularVelocity = 0;
            ship.GetComponent<TopDownShipController>().setCanMove(false);
        }
    }

    private void ToggleMenu() {
        inMenu = !inMenu;
    }
}
