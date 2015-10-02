using UnityEngine;
using System.Collections;

public class backgroundControl : MonoBehaviour {

    //public float scrollPosition;

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        /*//Reset position of scrolling background plate
        scrollPosition = transform.position.z;

        if (transform.position.z >= 10f)
        {
            scrollPosition = -10f;  
        }*/

        //basic background movements
        transform.Translate(Vector3.back * Time.deltaTime);

        //Tried to base the background speed on player speed and this made things very wierd, do not try
        //var backgroundSpeed = playerShip.playerBasicMovementSpeed;
        
        /*
        if (backgroundSpeed <= 5f)
        {
            transform.Translate(Vector3.forward * backgroundSpeed * Time.deltaTime);
        }
        else if (backgroundSpeed >= 10f)
        {
            transform.Translate(Vector3.forward * backgroundSpeed * Time.deltaTime);
        }
  */
	}
    
    /*public float scrollPosition
    {
        get { return this.transform.position.z; }
        set { this.transform.position.z = scrollPosition; }
    }*/

}

