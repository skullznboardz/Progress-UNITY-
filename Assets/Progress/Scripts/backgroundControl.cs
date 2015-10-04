using UnityEngine;
using System.Collections;

public class backgroundControl : MonoBehaviour {

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //basic background movements
        if (transform.position.z >= -10f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        else if (transform.position.z <= -10f)
        {
            //Reset position of scrolling background plate
            Vector3 scrollPosition = new Vector3(0, 0, 10f);
            transform.position = scrollPosition;
        }

        //Boundaries for the ship


	}
    
}

