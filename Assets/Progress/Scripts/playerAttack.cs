using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

    public float basicBulletSpeed = 15f;

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
}
