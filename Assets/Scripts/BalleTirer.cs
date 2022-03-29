using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleTirer : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float forceImpact;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        health = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GrossirBalle(float health)
    {
        this.health += health;
        gameObject.transform.localScale = new Vector3(this.health * 2, this.health * 2, this.health * 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            collision.GetContact(0);
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((collision.gameObject.transform.position - gameObject.transform.position).normalized * gameObject.GetComponent<Rigidbody>().velocity.z, collision.GetContact(0).point);
            Debug.Log("yo");
        }
    }

}