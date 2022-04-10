using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeReduction : MonoBehaviour
{
    [SerializeField] float vitesseDonner;
    GameObject player;
    bool inIt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inIt)
        {
            AjouterVieAPlayer();
        }
    }

    void AjouterVieAPlayer()
    {
        if (player.GetComponent<PlayerHealth>().TropVie())
        {
            player.GetComponent<PlayerHealth>().RetirerViePourTuer(Time.deltaTime * vitesseDonner);
           
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
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
