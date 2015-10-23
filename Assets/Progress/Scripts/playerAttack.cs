using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

    public float basicBulletSpeed = 15f;

    private float enemyHealthCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * basicBulletSpeed * Time.deltaTime);

        if (transform.position.z >= 4.1f)
        {
            Destroy(gameObject, .5f);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        //Detects that if the collider called out aboce is in layer 8
        if (other.gameObject.layer == 11)
        {
            enemyHealthCheck = other.gameObject.GetComponentInParent<basicEnemy>().enemyHealth;
            enemyHealthCheck -= 10f;
            other.gameObject.GetComponentInParent<basicEnemy>().enemyHealth = enemyHealthCheck;

            Destroy(gameObject);
        }
    }

}
