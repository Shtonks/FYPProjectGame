using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject explosionObj;
    public int dmgAmount;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().TakeDmg(dmgAmount);
            Debug.Log("Player hit by enemy");
        }

        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shield") {
            GameObject expl = Instantiate(explosionObj, transform.position, Quaternion.identity);
            Destroy(expl, 2.12f);
            Destroy(gameObject);
        }
    }
}
