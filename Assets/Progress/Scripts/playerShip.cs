using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour {

    //public int playerLives = 1;
    //Must apply 'static' keyword to get variable to be accessed in other script
    public static float playerBasicMovementSpeed = 1f;
    public float playerLateralMovementSpeed = 5f;
    public float playerThrusterMovementSpeed = 30f;
    public float playerAirBrakeSpeed = -10f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Basic Player Movement
        if(Input.GetKey(KeyCode.W))
        {
            //playerBasicMovementSpeed = 15f;
            transform.Translate(Vector3.forward * playerThrusterMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //playerBasicMovementSpeed = .1f;
            transform.Translate(Vector3.back * playerAirBrakeSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerLateralMovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerLateralMovementSpeed * Time.deltaTime);
        }
        else 
        {
            playerBasicMovementSpeed = 1f;
        }
        //Lateral Controls
        //Thruster Controls
        //Air Brakes
    


        //Player Attack
        if (Input.GetKey(KeyCode.Space))
        {
            //Spawn projectile
            
        }
        
        //Player Hit Detection

        //Player Lives


	}
}
