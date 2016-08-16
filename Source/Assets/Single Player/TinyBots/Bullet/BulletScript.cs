using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public string shootingPlayer;

	float speed = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (GetComponent<Rigidbody2D> ().velocity);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//print (coll.gameObject.tag);
		if (coll.gameObject.tag == "BossHead") {
			if (coll.gameObject.GetComponent<HeadTakeDamage> ().HurtMe ()) {
				GetInputToJoin.PlayerWhoIsBoss = shootingPlayer;
				//GetInputToJoin.PlayerWhoIsBoss = shootingPlayer;
				print ("new god of war: " + shootingPlayer);
				GameObject.Find ("LetPlayersJoin").GetComponent<GetInputToJoin> ().DisplayMessage ();
			}
		}
		Destroy (gameObject);

	}
}
