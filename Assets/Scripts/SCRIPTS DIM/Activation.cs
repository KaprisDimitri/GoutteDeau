using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public bool active;
    public bool ChangeColor;
    public Material checkMateriel;
    public Material unCheckMateriel;
    public MeshRenderer changeColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Movable" || other.gameObject.tag == "Ball")
        {
            Debug.Log("yoyoy");
            active = !active;

            if(ChangeColor)
            {
                if(active)
                {
                    changeColor.material = checkMateriel;
                }
                else
                {
                    changeColor.material = unCheckMateriel;
                }
            }
            
        }
            
        
    }
}
