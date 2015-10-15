using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour {

    //public int playerLives = 1;
    public float playerMovementSpeed = 12.5f;

    //Bullet variable for setting prefab to spawn
    public Transform playerShipBullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Player Attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spawns the bullet that is attached to the first statement and at the position and rotation of the second statement (need to figure out how to correct the position)
            Instantiate(playerShipBullet, transform.position, transform.rotation);
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
	}
}
