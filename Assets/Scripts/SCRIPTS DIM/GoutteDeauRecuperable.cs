using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoutteDeauRecuperable : MonoBehaviour
{
    [SerializeField] bool infinie;

    [SerializeField] float healthToGive;
    [SerializeField] float vitesseDonner;
    GameObject player;
    bool inIt;
    float healthGiven;
    // Start is called before the first frame update
    void Start()
    {
        InitGoutteDonner();
    }

    // Update is called once per frame
    void Update()
    {
        if(inIt)
        {
            AjouterVieAPlayer();
        }
        
    }

    void InitGoutteDonner ()
    {
        gameObject.transform.localScale = new Vector3(healthToGive, healthToGive, healthToGive);
        
    }

    void AjouterVieAPlayer ()
    {
        if (player.GetComponent<PlayerHealth>().TropVie())
        {
            healthGiven += Time.deltaTime * vitesseDonner;
            if (!infinie)
            {
                if (healthGiven >= healthToGive)
                {
                    healthGiven = healthToGive;
                }
                ChangeGrosseur();
               // player.GetComponent<PlayerHealth>().AjouterVie(Time.deltaTime * vitesseDonner);
                DestroyGoutteDeau();
            }
            player.GetComponent<PlayerHealth>().AjouterVie(Time.deltaTime * vitesseDonner);
        }
    
    }

    void ChangeGrosseur ()
    {
        gameObject.transform.localScale = new Vector3(healthToGive - healthGiven, healthToGive- healthGiven, healthToGive- healthGiven);
    }

    void DestroyGoutteDeau()
    {
        if (healthGiven >= healthToGive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inIt = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inIt = false;
        }
    }
}
