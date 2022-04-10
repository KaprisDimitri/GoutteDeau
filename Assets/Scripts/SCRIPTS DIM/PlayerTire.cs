using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTire : MonoBehaviour
{
    [SerializeField] GameObject spawBallPos;
    [SerializeField] GameObject balleToSpawn;
    [SerializeField] float vitesseGrossisementBalle;
    [SerializeField] float vitesseDeLancer;



    PlayerInputAction inputActions;



    GameObject ballSpawn;

    bool load;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputAction();
        EnableShooting(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (load)
        {
            GrossirBall();
        }
    }

    void EnableShooting(bool active)
    {
        if (active)
        {
            inputActions.PlayerMove.Shoot.Enable();
            inputActions.PlayerMove.Shoot.performed += Shoot;
            inputActions.PlayerMove.Shoot.canceled += Shoot;
        }
        else
        {
            inputActions.PlayerMove.Shoot.Disable();
        }
    }

    void Shoot(InputAction.CallbackContext obj)
    {

        if (obj.performed)
        {
            if (GetComponent<PlayerHealth>().PasAsserVie())
            {
                ballSpawn = Instantiate(balleToSpawn, spawBallPos.transform.position, gameObject.transform.rotation);
                GetComponent<PlayerHealth>().RetirerVie(0.1f);

                load = true;
            }
        }
        else if (obj.canceled)
        {
            
            load = false;
            TirerBalle();
        }

    }

    void GrossirBall()
    {
        if (ballSpawn.GetComponent<BalleTirer>().health < ballSpawn.GetComponent<BalleTirer>().maxHealth && GetComponent<PlayerHealth>().PasAsserVie())
        {
            ballSpawn.GetComponent<BalleTirer>().GrossirBalle(Time.deltaTime * vitesseGrossisementBalle);
            ballSpawn.transform.position = spawBallPos.transform.position;
            GetComponent<PlayerHealth>().RetirerVie(Time.deltaTime * vitesseGrossisementBalle);
        }
        else
        {
            load = false;
        }
    }

    void TirerBalle()
    {
        ballSpawn.GetComponent<Rigidbody>().useGravity = true;
        ballSpawn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0.5f,1) * vitesseDeLancer);
    }
}
