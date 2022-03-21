using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float healthMax;
    [SerializeField] float healthMin;
    [SerializeField] float vitesseDeplacement;
    [SerializeField] GameObject spawnBall;
    [SerializeField] GameObject balleToSpawn;
    [SerializeField] float vitesseGrossisementBalle;
    [SerializeField] float vitesseDeLancer;
    PlayerInputAction inputActions;
    GameObject ballSpawn;
    float health;
   public  bool aim;
    public bool load;
    public bool shoot;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        InitPlayerControler();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(inputActions.PlayerMove.Move.ReadValue<Vector2>());

        if(load)
        {
            GrossirBall();
        }
    }


    void InitPlayerControler ()
    {
        inputActions = new PlayerInputAction();
        inputActions.PlayerMove.Move.Enable();
        inputActions.PlayerMove.Aim.Enable();
        
        inputActions.PlayerMove.Aim.performed += AimingOrNot;
        


        health = 3;
        GrossirPlayer(health);


    }

    public void AjouterVie (float vie)
    {
        if(TropVie())
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
    public bool PasAsserVie()
    {
        if (health <= healthMin)
        {
            return false;
        }
        return true;

    }


    public bool TropVie ()
    {
        if (health >= healthMax)
        {
            return false;
        }
        return true;
           
    }

    void GrossirPlayer (float health)
    {
        gameObject.transform.localScale = new Vector3(health, health, health);
    }

    public void MovePlayer (Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(direction.x,0,direction.y) * vitesseDeplacement * Time.deltaTime);
    }

    void EnableShooting (bool active)
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

    

    void AimingOrNot (InputAction.CallbackContext obj)
    {
        if(aim)
        {
            aim = false;
            EnableShooting(false);
        }
        else
        {
            if (!shoot)
            {
                aim = true;
                EnableShooting(true);
            }
        }
    }
    void Shoot(InputAction.CallbackContext obj)
    {
        
        if(obj.performed)
        {
            ballSpawn = Instantiate(balleToSpawn, spawnBall.transform.position, gameObject.transform.rotation);
            RetirerVie(0.1f);
            shoot = true;
            load = true;
            

            
        }
        else if (obj.canceled)
        {
            shoot = false;
            load = false;
            TirerBalle();
        }

    }

    void GrossirBall ()
    {
        if (ballSpawn.GetComponent<BalleTirer>().health < ballSpawn.GetComponent<BalleTirer>().maxHealth && PasAsserVie())
        {

            ballSpawn.GetComponent<BalleTirer>().GrossirBalle(Time.deltaTime * vitesseGrossisementBalle);
            ballSpawn.transform.position = spawnBall.transform.position;
            RetirerVie(Time.deltaTime * vitesseGrossisementBalle);
        }
        else
        {
            load = false;
        }
    }

    void TirerBalle ()
    {
        ballSpawn.GetComponent<Rigidbody>().useGravity = true;
        ballSpawn.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*vitesseDeLancer);
    }




 }
