using UnityEngine;
using System.Collections;

public class basicEnemyAI : MonoBehaviour {

    //Basic Enemy
    public Transform basicEnemy;

    public static float numberOfEnemies = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //Basic Enemy Spawning
        if (numberOfEnemies < 2)
        {
            //Spawns the bullet that is attached to the first statement and at the position and rotation of the second statement (need to figure out how to correct the position)
            Instantiate(basicEnemy, new Vector3(Random.Range(-4, 4), 0f, 7.5f), Quaternion.Euler(0,180,0));
            numberOfEnemies = numberOfEnemies + 1;
        }

	}

}
