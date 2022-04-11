using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float healthMin;
    [SerializeField] float healthMax;

    // Start is called before the first frame update
    void Start()
    {
        GrossirPlayer(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitHealthPlayer (float health, float healthMax, float healthMin)
    {
        this.health = health;
        this.healthMax = healthMax;
        this.healthMin = healthMin;
    }

    public void ResetPlayer ()
    {
        health = 1;
        GrossirPlayer(health);
    }

    public void AjouterVie(float vie)
    {
        if (TropVie())
        {
            health += vie;
            GrossirPlayer(health);
        }
    }

    public void RetirerVie(float vie)
    {
        if (PasAsserVie())
        {
            health -= vie;
            GrossirPlayer(health);
        }
    }

    public void RetirerViePourTuer(float vie)
    {
        if (!Mort())
        {
            health -= vie;
            GrossirPlayer(health);
        }
    }
    public bool PasAsserVie()
    {
        if (health <= healthMin)
        {
            return false;
        }
        return true;
    }

    public bool Mort()
    {
        if (health <= 0.2)
        {
            return true;
        }
        return false;
    }


    public bool TropVie()
    {
        if (health >= healthMax)
        {
            return false;
        }
        return true;

    }

    void GrossirPlayer(float health)
    {
        gameObject.transform.localScale = new Vector3(health/4, health / 4, health / 4);
    }
}
