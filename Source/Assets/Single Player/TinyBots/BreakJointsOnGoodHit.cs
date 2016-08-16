using UnityEngine;
using System.Collections;

public class BreakJointsOnGoodHit : PlayerScriptBase {

	HingeJoint2D thisJoint;
	public HingeJoint2D[] myJoints;
	PlayerScriptBase[] myScripts;
	float deathHit = 999; 
	bool broke = false;
    public bool hasJoints = true;

    public IsPlayerDead amIDead;

	// Use this for initialization
	void Start () {
		thisJoint = GetComponent<HingeJoint2D> ();
        if (hasJoints)
        {
            myJoints = transform.parent.GetComponentsInChildren<HingeJoint2D>();
        }
		myScripts = transform.parent.GetComponentsInChildren<PlayerScriptBase> ();
	}
	
	// Update is called once per frame
	void Update () {
		// falling off the stage is also fatal
		//if (transform.position.y < -10) {
		//	GetComponentInParent<IsPlayerDead> ().dead = true;
		//}

		if (thisJoint == null && hasJoints) {
			print (gameObject.name);
			Break ();
		}
	}

	void OnJointBreak(float breakForce) {
		Debug.Log("Joint Broke!, force: " + breakForce);
	}

	void Break() {

        amIDead.dead = true;

		broke = true;

        //print(myJoints.Length);

		foreach (HingeJoint2D joint in myJoints) {
			if (joint != null) {
				joint.breakForce = 1;
			}
		}
		foreach (PlayerScriptBase script in myScripts) {
            //set all objects to default layer
            script.gameObject.layer = LayerMask.NameToLayer("DeadPlayer") ;
			script.enabled = false;
		}

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (broke)
        {
            return;
        }
        if (other.gameObject.tag == "Trap")
        {
            GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 30);
            broke = true;
            Break();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
		if (broke) {
			return;
		}
		if (coll.gameObject.tag == "Trap") {
            broke = true;
            Vector2 bashForce = new Vector2(transform.position.x - coll.contacts[0].point.x, transform.position.y - coll.contacts[0].point.y) * 5;
            GetComponent<Rigidbody2D>().AddForce(bashForce);
            Break();
		}
	}
	
}
