using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFactionToMap : MonoBehaviour
{
    public PlayerBehaviour pb;
    private string factionName;
    // Start is called before the first frame update
    void Start()
    {
        factionName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("FCTION NAME: " + factionName);
            pb.playerUIManager.UpdateMapFaction(gameObject.transform.position, factionName);
        }
    }
}
