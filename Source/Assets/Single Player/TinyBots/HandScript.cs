using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour {

	public GameObject bullet;

	Rigidbody2D myRigidbody;
	//public FixedJoint2D gripper;

	Rigidbody2D[] allRigidBodies;

	public string PlayerNumber;

	float timeToShoot = 0.1f;
	float maxTimeToNextShoot = 0.3f;

	bool gripping = false;
	bool gripperEnabled = false;
	FixedJoint2D newFixedJoint;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		allRigidBodies = transform.parent.GetComponentsInChildren<Rigidbody2D> ();
		PlayerNumber = transform.parent.GetComponentInChildren<MoveScript> ().PlayerNumber;
	}

	// Update is called once per frame
	void Update () {

		Vector2 desieredDir = Vector2.zero;
		//print (desieredDir);

		//if (Input.GetAxis ("Horizontal_Right") != 0) {
		desieredDir.x += Input.GetAxis ("Horizontal_Right"+PlayerNumber) * 0.5f;
		//}
		//if (Input.GetAxis ("Vertical_Right") != 0) {
		desieredDir.y += Input.GetAxis("Vertical_Right"+PlayerNumber) * 0.5f;


		if (desieredDir.magnitude != 0) {
			if (gameObject.layer == 12) {
				return;
			}
			timeToShoot -= Time.deltaTime;
			if (timeToShoot < 0) {
				timeToShoot = Random.Range (0f, maxTimeToNextShoot);
				GameObject newbullet = Instantiate (bullet, transform.position, Quaternion.LookRotation(new Vector3(desieredDir.x, desieredDir.y, 0))) as GameObject;
				newbullet.GetComponent<BulletScript> ().shootingPlayer = PlayerNumber;
			}
		}
		//}
		Vector2 posIn2d = new Vector2(transform.position.x, transform.position.y);
		myRigidbody.AddForce (desieredDir);
	}

	Vector3 Vector3Division(Vector3 one, Vector3 two){
		Vector3 newVec = new Vector3 (one.x / two.x, one.y / two.y, one.z / two.z);
		return newVec;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		/*
		if (gripping) {
			gripperEnabled = true;
			newFixedJoint = coll.gameObject.AddComponent<FixedJoint2D> ();
			newFixedJoint.connectedBody = myRigidbody;
			//newFixedJoint.connectedAnchor = coll.gameObject.transform.position - transform.position;
			newFixedJoint.autoConfigureConnectedAnchor = true;




			//newFixedJoint.connectedAnchor = (Vector3Division(coll.transform.position, coll.transform.lossyScale) - Vector3Division(transform.position , gameObject.transform.lossyScale)) ;
			//float tileWidth = coll.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
			//newFixedJoint.connectedAnchor = new Vector2(tileWidth, 0);
			//foreach (Rigidbody2D body in allRigidBodies) {
			//	body.gravityScale = 0.0001f;
			//}
		}
		*/
	}


}
