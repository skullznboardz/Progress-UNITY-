using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour {

    //public int playerLives = 1;
    //Must apply 'static' keyword in between the public and float statements to get variable to be accessed in other script
    public float playerBasicMovementSpeed = 1f;
    public float playerLateralMovementSpeed = 5f;
    public float playerThrusterMovementSpeed = 30f;
    public float playerAirBrakeSpeed = -10f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Basic Player Movement
        //Thruster Controls
        if(Input.GetKey(KeyCode.W))
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
        else 
        {
            //Players default speed when no input is applied
            playerBasicMovementSpeed = 1f;
        }
        
        //Player Attack
        if (Input.GetKey(KeyCode.Space))
        {
            
            
        }
        
        //Player Hit Detection

        //Player Lives


	}
}
