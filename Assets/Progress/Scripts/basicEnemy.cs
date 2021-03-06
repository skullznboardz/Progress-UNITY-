﻿using UnityEngine;
using System.Collections;



public class basicEnemy : MonoBehaviour {

    //Enemy Movement Variable
    public float enemyBasicMovementSpeed = 12f;

    //Bullet variable for setting prefab to spawn
    public GameObject enemyShipBullet;

    //Limiting Enemny Fire Rate
    public float EnemyFire = 0;

    public float enemyHealth = 10;
	
	// Update is called once per frame
	void Update () {
        //Enemy Movement
        transform.Translate(Vector3.forward * enemyBasicMovementSpeed * Time.deltaTime);

        if(transform.position.z <= -10)
        {
            Destroy(gameObject, 0f);
            basicEnemyAI.numberOfBasicShips -= 1;
        }
       
        //Converts RaycastHit to the variable hit to be used in the hit raycast hitdetection 
        RaycastHit hit;
        //Enemy Attack
        //If, when casting a ray out from the ships positions in the direction its facing, forward, it hits at infinite distance the player layer then execute command
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, game.Instance.PlayerLayerMask) && EnemyFire < 1)
        {
            //Spawns the bullet that is attached to the variable enemyShipBullet and at the position and rotation of the second statement
            GameObject enemyBullet = Instantiate(enemyShipBullet, transform.position, transform.rotation) as GameObject;
            enemyBullet.transform.parent = transform;
            //Instantiate(enemyShipBullet, transform.position, transform.rotation);
            EnemyFire++;
            //Debug.Log(EnemyFire);
        }

        if (enemyHealth <= 0)
        {         
            enemyHealth = 0;
            basicEnemyAI.numberOfBasicShips -= 1;

            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision playerBullet)
    {
        //Detects that if the collider called out aboce is in layer 8
        if (playerBullet.gameObject.layer == 10)
        {
            Debug.Log("EnemyHit");
            //Destroy(gameObject);
        }
    }
}
