using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneFin : MonoBehaviour
{
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
        Debug.Log("GG Tu as Gagner");
        if (other.gameObject.layer == 3)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
