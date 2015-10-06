using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour {

    //public int playerLives = 1;
    //Must apply 'static' keyword in between the public and float statements to get variable to be accessed in other script
    public float playerBasicMovementSpeed = 1f;
    public float playerLateralMovementSpeed = 5f;
    public float playerThrusterMovementSpeed = 30f;
    public float playerAirBrakeSpeed = -10f;

    //Variable for target objects to allow angled player movement
    public Transform forwardLeftTarget;
    public Transform forwardRightTarget;
    public Transform backLeftTarget;
    public Transform backRightTarget;

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
        //Angle Controls for the ship movement using other actors in the scene(this may not be the most optimal way to do this but it works pretty good right now)
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) 
        {
            transform.position = Vector3.MoveTowards(transform.position, forwardLeftTarget.position, playerLateralMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, forwardRightTarget.position, playerLateralMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, backLeftTarget.position, playerLateralMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, backRightTarget.position, playerLateralMovementSpeed * Time.deltaTime);
        }
        //Thruster Controls
        else if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerThrusterMovementSpeed * Time.deltaTime);
        }
        //Air Brakes
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerAirBrakeSpeed * Time.deltaTime);
        }
        //Lateral Controls
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerLateralMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerLateralMovementSpeed * Time.deltaTime);
        }
      
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
