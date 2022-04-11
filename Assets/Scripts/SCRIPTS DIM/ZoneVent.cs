using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneVent : MonoBehaviour
{
    [SerializeField] Activation activation;

    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject endPoint;

    [SerializeField] float ForceVent;
    [SerializeField] GameObject VisuZoneVent;


    public bool active;
    

    List<GameObject> objetDansVent;

    // Start is called before the first frame update
    void Start()
    {
        InitZoneVent();
    }

    // Update is called once per frame
    void Update()
    {
        if (activation != null)
        {
            active = activation.active;
        }
        if(active)
        {
            VisuZoneVent.SetActive(true);
            EmissionForce();
        }
        else
        {
            VisuZoneVent.SetActive(false);
        }
    }

    public void ActivationDeVent(bool active)
    {
        active = activation.active;
        objetDansVent = new List<GameObject>();
    }

    void InitZoneVent ()
    {
        active = true;
        objetDansVent = new List<GameObject>();
    }

    void RetirerObjetDansListe (GameObject objet)
    {
        for(int i = 0; i< objetDansVent.Count;i++)
        {
            if(objetDansVent[i] == objet)
            {
                objetDansVent[i] = null;
                break;
            }
        }
    }

    void EmissionForce()
    {
        for(int i =0;i< objetDansVent.Count;i++)
        {
            if (objetDansVent[i] != null)
            {
                objetDansVent[i].GetComponent<Rigidbody>().velocity = (((endPoint.transform.position - startPoint.transform.position).normalized) * ForceVent);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            objetDansVent.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(active)
        {
            RetirerObjetDansListe(other.gameObject);
        }
    }



}
