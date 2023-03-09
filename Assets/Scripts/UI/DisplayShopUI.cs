using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject shopUIPrompt;
    //[SerializeField] private float speedToCentre = 1.5f;
    [SerializeField] private GameObject ship;

    private bool shopColl;

    private Rigidbody2D shipRb;

    // Start is called before the first frame update
    void Awake()
    {
        shopColl = false;
        shipRb = ship.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checks if player is in range of shop and displays if so
        if(Input.GetKeyDown(KeyCode.R) && shopColl) {
            Debug.Log("In player shop");
            //stops ship moving
            shipRb.velocity = Vector2.zero;
            shipRb.angularVelocity = 0;
            ship.GetComponent<TopDownShipController>().setCanMove(false);
            //sets the position of ship to be middle of shop
            //shipController.setPos(Vector2.MoveTowards(shipController.getPos(), transform.position, speedToCentre * Time.deltaTime));
            //ship.transform.position = Vector2.MoveTowards(ship.transform.position, transform.position, speedToCentre * Time.deltaTime);

            shopUIPrompt.SetActive(false);
            shopUI.SetActive(true);
            Debug.Log("Still here player shop");
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            ship.GetComponent<TopDownShipController>().setCanMove(true);
            closeMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            shopColl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            shopColl = false;
        }
    }

    void closeMenu() {
        shopUI.SetActive(false);
    }
}
