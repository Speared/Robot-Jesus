using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

    public bool clockwise;
    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        if (clockwise)
        {
            //print("did this");
            myRigidbody.angularVelocity = 999;
        }
        else
        {
            myRigidbody.angularVelocity = -999;
        }
	}
}
