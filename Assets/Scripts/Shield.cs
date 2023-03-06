using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private CircleCollider2D col;
    private SpriteRenderer sr;

    private int countdown = 7;
    public float countdownInterval = 2f;
    public float rechargeInterval = 4f;
    public List<GameObject> shieldStatusBar;
    private float currentTime = 0f;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), col);
        }

        if (collision.gameObject.tag == "Bomber")
        {
            Destroy(collision.gameObject);
            GetComponentInParent<PlayerBehaviour>().Heal(1);
            Debug.Log("Shield destroyed enemy");
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleShield();
        }
    }

    void FixedUpdate()
    {
        if(col.enabled) {
            ShieldCountdown();
        }

        if(!col.enabled && countdown < 7) {
            ShieldRecharge();
        }
    }

    private void ToggleShield() {
        col.enabled = !col.enabled;
        sr.enabled = !sr.enabled;
        Debug.Log("Togglging shield");
    }

    private void ShieldCountdown() {
        currentTime += Time.deltaTime;

        if(currentTime >= countdownInterval) {
            Debug.Log("Countdown:" + countdown);
            shieldStatusBar[countdown].SetActive(false);
            countdown--;
            currentTime = 0f;
        }
        if(countdown == 0) {
            shieldStatusBar[countdown].SetActive(false);
            ToggleShield();
        }
    }

    private void ShieldRecharge() {
        currentTime += Time.deltaTime;

        if(currentTime >= rechargeInterval) {
            Debug.Log("Recharge:" + countdown);
            shieldStatusBar[countdown].SetActive(true);
            currentTime = 0f;
            countdown++;
        }
        if(countdown == 7) {
            shieldStatusBar[countdown].SetActive(true);
        }
    }
}
