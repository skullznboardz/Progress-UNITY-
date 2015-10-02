using UnityEngine;
using System.Collections;

public class ReelControll : MonoBehaviour {

    //This script controls the reel spinning animation, when it starts and when it stops.

    //How fast the reel spins
    public float rateOfSpin = 50;
    //How long the reel spins for
    public float spinTime = 5;
    //The position the reel should stop at
    private float stopPosition = 0;
    //The time it takes for one revolution of the reel
    public float animationTime = 5;
    //The angle the rotation will be at
    private float rotationAngle = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
  
    }

   //public void launchReels()
   //{

    //}
}