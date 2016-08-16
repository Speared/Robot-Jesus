using UnityEngine;
using System.Collections;

public class Boss_InputController : MonoBehaviour {

	public string right_or_left;
	public SpriteRenderer hand_renderer;
	private string playerNumber;
	public ParticleSystem particleSystem;
	private SpriteRenderer[] knuckles;

	Rigidbody2D boss_hand;
	Boss_Monster b_master;

	Joint2D myJoint;

	bool staminaLock = false;
	float stamina = 21;
	float maxStamina = 21;

	public float fRotationLock = -90f;
	// Use this for initialization
	void Start () {
		myJoint = GetComponent<Joint2D> ();
		boss_hand = GetComponent<Rigidbody2D> ();
		b_master = GetComponentInParent<Boss_Monster> ();
		knuckles = hand_renderer.gameObject.GetComponentsInChildren<SpriteRenderer>();
	}

	//Collision
	void OnCollisionEnter2D(Collision2D coll) {

	}

	// Update is called once per frame
	void Update () {
		playerNumber = GetInputToJoin.PlayerWhoIsBoss;
		float fSpeed = 15500.00f;

		if (Input.GetAxis (right_or_left + "_Bumper" + playerNumber) != 0.0f && !staminaLock) {
			myJoint.enabled = false;
			fSpeed *= 6f;
			stamina -= Time.deltaTime * 48 / GetInputToJoin.numPlayers;
			if (stamina < 7) {				
				//hand_renderer.color = new Color(1, 0.5f, 0.5f);
				for (int i = 1; i < knuckles.Length; i++) {
					knuckles[i].color = new Color(1, 0.5f, 0.5f);
				}
				boss_hand.angularVelocity *= -1;
				particleSystem.gameObject.SetActive (true);
			} else if (stamina < 14) {
				particleSystem.gameObject.SetActive (false);
				//hand_renderer.color = Color.yellow;
				for (int i = 1; i < knuckles.Length; i++) {
					knuckles[i].color = Color.yellow;
				}
			} else {
				//hand_renderer.color = new Color (0.5f, 1, 0.5f);
				for (int i = 1; i < knuckles.Length; i++) {
					knuckles[i].color = new Color (0.5f, 1, 0.5f);
				}
			}

			if (stamina < 0) {
				print ("stamina locked");
				staminaLock = true;
				for (int i = 1; i < knuckles.Length; i++) {
					knuckles [i].color = Color.red;
				}
			}
		} else {
			myJoint.enabled = true;

			stamina += Time.deltaTime * 4 * GetInputToJoin.numPlayers;
			if (stamina > maxStamina) {
				stamina = maxStamina;
				staminaLock = false;
				//print ("stamina unlocked");
				for (int i = 1; i < knuckles.Length; i++) {
					knuckles [i].color = Color.green;
				}
				particleSystem.gameObject.SetActive (false);
			}
		}

		string sAdjust = "";
		if (right_or_left == "Left")
			sAdjust = "";
		else
			sAdjust = "_Right";

		float fHorizontal = Input.GetAxis ("Horizontal"+sAdjust+playerNumber) * fSpeed;
		float fVertical = Input.GetAxis ("Vertical"+sAdjust+playerNumber) * fSpeed;

		Vector3 v=new Vector3(fHorizontal*Time.deltaTime,fVertical*Time.deltaTime,0);

		boss_hand.AddForce (v);


		if (boss_hand.rotation != fRotationLock) {
			if (boss_hand.rotation < fRotationLock) {
				boss_hand.angularVelocity += 60f * Time.deltaTime;
			}
			else {
				boss_hand.angularVelocity += -60f * Time.deltaTime;;
			}

			if (Mathf.Abs (boss_hand.rotation - fRotationLock) < 1)
				boss_hand.angularVelocity = 0;
		}
	}
}