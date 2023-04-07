using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject explosionObj;
    private CircleCollider2D col;
    private SpriteRenderer sr;

    // Scaling from centre
    public Vector3 biggestScale;
    public Vector3 smallestScale;
    public float scalingRate;

    // Shield recharge
    private int countdown = 7;
    public float countdownInterval;
    public float rechargeInterval;
    public List<GameObject> shieldStatusBar;
    private float currentTime = 0f;

    private PlayerBehaviour pb;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        pb = GetComponentInParent<PlayerBehaviour>();
        countdownInterval = pb.shieldCountdownInterval;
        rechargeInterval = pb.shieldRechargeInterval;
    }

    private void Update() {
        countdownInterval = pb.shieldCountdownInterval;
        rechargeInterval = pb.shieldRechargeInterval;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleShield();
        }
    }

    void FixedUpdate()
    {
        if(col.enabled) {
            transform.localScale = Vector3.MoveTowards(transform.localScale, biggestScale, scalingRate * Time.deltaTime);
            ShieldCountdown();
        }

        if(!col.enabled && countdown <= 7) {
            transform.localScale = smallestScale;
            ShieldRecharge();   
        }
    }

    private void ToggleShield() {
        col.enabled = !col.enabled;
        sr.enabled = !sr.enabled;
    }

    private void ShieldCountdown() {
        currentTime += Time.deltaTime;

        if(currentTime >= countdownInterval) {
            //Debug.Log("Countdown:" + countdown);
            shieldStatusBar[countdown].SetActive(false);
            countdown--;
            currentTime = 0f;
        }
        if(countdown <= -1) {
            //shieldStatusBar[countdown].SetActive(false);
            countdown++;
            ToggleShield();
        }
    }

    private void ShieldRecharge() {
        currentTime += Time.deltaTime;

        if(currentTime >= rechargeInterval) {
            //Debug.Log("Recharge:" + countdown);
            shieldStatusBar[countdown].SetActive(true);
            currentTime = 0f;
            countdown++;
        }
        if(countdown >= 8) {
            countdown--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bomber")
        {
            GetComponentInParent<PlayerBehaviour>().Heal(1);
            GameObject expl = Instantiate(explosionObj, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 2.12f);
            Destroy(collision.gameObject);
            Debug.Log("Shield destroyed enemy");
        }
    }

}
