using UnityEngine;
using System.Collections;

public class BodyStabilizer : PlayerScriptBase {

	Rigidbody2D myRigidbody;
	float stablizingForce = 1;
	GroundChecker myGroundChecker;
    public Transform wheelTransform;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myGroundChecker = transform.parent.GetComponentInChildren<GroundChecker> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float forceMultiplier = 1;
        //float maxForceMultiplier = 0.333333333f * myGroundChecker.passedGroundChecks;
        float maxForceMultiplier = 15f;
        float turnAngle = Vector3.Angle(transform.up, wheelTransform.up);

        forceMultiplier = Mathf.Clamp(turnAngle, 0, maxForceMultiplier);

        
        Vector3 reletivePoint = transform.InverseTransformPoint(wheelTransform.position);

        print(reletivePoint.x);
        //left
        if (reletivePoint.x < 0 && myRigidbody.angularVelocity < 0)
        {
            //print("Right");
            myRigidbody.AddTorque(stablizingForce * forceMultiplier);
        }
        else if(reletivePoint.x > 0 && myRigidbody.angularVelocity > 0)
        {
            print("Left");
            myRigidbody.AddTorque(-stablizingForce * forceMultiplier);
        }

        /*
		if (transform.rotation.z > 0f && transform.rotation.z < 180) {
			//if (transform.rotation.z > 0f) {

			forceMultiplier = transform.rotation.z;
			forceMultiplier = Mathf.Clamp (forceMultiplier, 0, maxForceMultiplier);
			myRigidbody.AddTorque (-stablizingForce * forceMultiplier);
			//print (stablizingForce * forceMultiplier);
		}else{
			forceMultiplier = (-transform.rotation.z);
			forceMultiplier = Mathf.Clamp (forceMultiplier, 0, maxForceMultiplier);
			myRigidbody.AddTorque (stablizingForce * forceMultiplier);

		}
        */
	}
}
