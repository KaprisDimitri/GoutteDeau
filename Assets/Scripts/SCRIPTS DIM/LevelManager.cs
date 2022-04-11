using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject StartPosition;

    public PlayerHealth playerHealth;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.Mort())
        {
            player.GetComponent<PlayerHealth>().ResetPlayer();
            player.gameObject.transform.position = StartPosition.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerHealth>().ResetPlayer();
            other.gameObject.transform.position = StartPosition.transform.position;
        }
    }
}
