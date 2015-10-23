using UnityEngine;
using System.Collections;

public class basicEnemyAttack : MonoBehaviour {

    public float basicBulletSpeed = 15f;

    private float playerHealthCheck;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Enemy bullet movement
        //It is also to move this forward with force. Is this something that we want to try and do?
        transform.Translate(Vector3.forward * basicBulletSpeed * Time.deltaTime);

        if (transform.localPosition.z >= 30f)
        {
            //Calls a common logic string that updates ship bullet numbers and runs the reload/cooldown timer
            bulletCountUpdate();
            //Destroy this game object
            Destroy(gameObject);
        }
	}

    //Requires a rigid body to be attached to one of the actors detecting the colision
    void OnCollisionEnter(Collision other)
    {
        //Detects that if the collider called out aboce is in layer 8
        if (other.gameObject.layer == 8)
        {
            bulletCountUpdate();
            
            playerHealthCheck = other.gameObject.GetComponentInParent<playerShip>().playerHealth;
            playerHealthCheck -= 10f;
            other.gameObject.GetComponentInParent<playerShip>().playerHealth = playerHealthCheck;
            //Debug.Log(playerHealthCheck);
            
            Destroy(gameObject);
            
            //Debug.Log("Player Hit");
        }

    }

    void bulletCountUpdate()
    {
        //Grab the EnemyFire variable from the objects parent script 'basicEnemy' and convert it to a local variable
        var bulletCount = transform.parent.GetComponent<basicEnemy>().EnemyFire;
        //Alter the variables value
        bulletCount -= 1;
        //Reassign that value back to the orignal value
        transform.parent.GetComponent<basicEnemy>().EnemyFire = bulletCount;

        //Returns to the previous script after this one has finished
        return;
    }

}
