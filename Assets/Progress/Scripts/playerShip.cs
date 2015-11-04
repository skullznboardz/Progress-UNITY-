using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour {

    //public int playerLives = 1;
    public float playerMovementSpeed = 12.5f;

    //Bullet variable for setting prefab to spawn
    public Transform playerShipBullet;

    public float playerHealth = 100;

	// Update is called once per frame
	void Update () {

        //Player Attack
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject playerAttackBasic = Instantiate(playerShipBullet, transform.position, transform.rotation) as GameObject;
            //playerAttackBasic.transform.parent = transform;
        }
        //Basic Player Movement
        float leftright = Input.GetAxis("Horizontal");
        float updown = Input.GetAxis("Vertical");

        transform.Translate((Vector3.right * leftright + Vector3.forward * updown) * Time.deltaTime * playerMovementSpeed, Space.World);
      
        /*Vector3 movement = Vector3.zero;
        //Thruster Controls
        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        transform.Translate(movement * playerLateralMovementSpeed * Time.deltaTime);*/
      
        //Player Hit Detection

        //Player Lives

        //Boundaries for the ship
        if (transform.position.z >= 4f)
        {
            //Is able to set an individual vector
            //Set a new Vector 3 variable as the current tranform position
            Vector3 upWall = transform.position;
            //Set the vector you want to change to the new value (here you can set any and all values)
            upWall.z = 4f;
            //Set the new value to the objects transform (this can be done to any set of values)
            transform.position = upWall;
        }
        
        if (transform.position.z <= -4f)
        {
            Vector3 downWall = transform.position;
            downWall.z = -4f;
            transform.position = downWall;
        }
        
        if (transform.position.x >= 4f) 
        {
            Vector3 leftWall = transform.position;
            leftWall.x = 4f;
            transform.position = leftWall;
        }
        
        if (transform.position.x <= -4f) 
        {
            Vector3 rightWall = transform.position;
            rightWall.x = -4f;
            transform.position = rightWall;
        }

        //Lose condition
        if(playerHealth <= 0)
        {
            playerHealth = 0;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Current Player Health is " + playerHealth);
        }


	}

    void OnCollisionEnter(Collision otherCollision)
    {
        Debug.Log("player ship hit by " + otherCollision.gameObject.transform.name);
    }
}
