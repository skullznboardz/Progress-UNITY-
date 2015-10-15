using UnityEngine;
using System.Collections;



public class basicEnemy : MonoBehaviour {

    //Enemy Movement Variable
    public float enemyBasicMovementSpeed = 12f;

    //Bullet variable for setting prefab to spawn
    public GameObject enemyShipBullet;

    //Limiting Enemny Fire Rate
    public float EnemyFire = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Enemy Movement
        transform.Translate(Vector3.forward * enemyBasicMovementSpeed * Time.deltaTime);

        if(transform.position.z <= -10)
        {
            Destroy(gameObject, 0f);
            basicEnemyAI.numberOfEnemies = basicEnemyAI.numberOfEnemies - 1;
        }
       
        //Converts RaycastHit to the variable hit to be used in the hit raycast hitdetection 
        RaycastHit hit;
        //Enemy Attack
        //If, when casting a ray out from the ships positions in the direction its facing, forward, it hits at infinite distance the player layer then execute command
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, game.Instance.PlayerLayerMask) && EnemyFire < 1)
        {
            //Spawns the bullet that is attached to the variable enemyShipBullet and at the position and rotation of the second statement (need to figure out how to correct the position)
            GameObject enemyBullet = Instantiate(enemyShipBullet, transform.position, transform.rotation) as GameObject;
            enemyBullet.transform.parent = transform;
            EnemyFire++;
            //Debug.Log(EnemyFire);
        }
	}

}
