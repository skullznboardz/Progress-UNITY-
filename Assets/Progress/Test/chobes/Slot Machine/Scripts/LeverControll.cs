using UnityEngine;
using System.Collections;

public class LeverControll : MonoBehaviour {

    //ANIMATION
    //The number of degree the lever will come down
    public float LeverDownRotation = -45;
    //The start position of the animation and the position it will return to - read in degreee aka 360 degrees
    public float LeverUpRotation = 0;
    //The accelerated return rate that the lever will go back to its starting position
    public float returnSpeed = 2;
    //The standard time it takes the lever to be pulled
    public float animationTime = 5;
    //The amount of 'bounce' appled to return animation
    public float bounceRate = 15;
    //Position of the lever in its current state. Ranges for 0 (start position) to 1 (end position)
    private float leverPosition = 0;
    //Still not sure what this does need to think about it some more
    private float animationRate = 0;

    //GAMEPLAY
    public float leverPulled = 0;

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Applies a new value to object once button has been pressed
        if (Input.GetMouseButtonDown(0))
        {
            animationRate = 1.0f / animationTime;

            if (leverPosition == .5)
            {
                //ReelControll.launchReels;
            }
        }
        
        //Lever State
        if(animationRate != 0.0f){
            leverPosition += animationRate * Time.deltaTime;
            
            //Defines where the position of the lever is
            if (leverPosition >= 1.0f)
            {
                //Sets the animation to automatically return by scaling the animation negativly by a scaled amount
                animationRate = -returnSpeed * animationRate;
                
            //resets the leverposition and animationrate if the lever has returned to its start state
            } else if (leverPosition <= 0.0f)
            {
                leverPosition = 0.0f;
                animationRate = 0.0f;

            }

            //Lever Animation
                //Set local rotation to not have asset parenting affect the animation at all
                //Set to SmoothStep to allow an 'ease in/ease out' style to the animation
                //Set a Mathf.Def2Rad to convert the angles from degerees to radials UPDATE - This is not needed if you use Euler instead of EulerAngles
                //Quarternion.EulerAngles (Euler said like Oiler) is required to get the shortest possible angle and not get gimble locked
            if(animationRate > 0){
                transform.localRotation = Quaternion.Euler(Mathf.SmoothStep(LeverUpRotation, LeverDownRotation, leverPosition), 0.0f, 0.0f);
            }
            else
            {
                float totalRotationAngle = LeverDownRotation-LeverUpRotation;
                float leverRotation = LeverUpRotation + (leverPosition * totalRotationAngle);
                transform.localRotation = Quaternion.Euler(leverRotation, 0, 0);
            }
        }
	}
}
