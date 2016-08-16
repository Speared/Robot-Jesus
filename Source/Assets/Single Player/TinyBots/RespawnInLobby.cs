using UnityEngine;
using System.Collections;

public class RespawnInLobby : MonoBehaviour {

	//obsolete way to do this
	/*
	IsPlayerDead myDead;
	public GameObject spawnMe;

	// Use this for initialization
	void Start () {
		myDead = GetComponent<IsPlayerDead> ();
	}

	IEnumerator WaitThenRespawn(){
		yield return new WaitForSeconds (2);
		GameObject newbot = Instantiate (spawnMe) as GameObject;
		newbot.GetComponentInChildren<MoveScript> ().PlayerNumber = GetComponentInChildren<MoveScript> ().PlayerNumber;
		RespawnInLobby newLobbyRespawn = newbot.AddComponent<RespawnInLobby> ();
		newLobbyRespawn.spawnMe = spawnMe;
		Destroy (gameObject);
	}
	*/
	// Update is called once per frame
	void Update () {
		//if (myDead.dead) {
		//	StartCoroutine (WaitThenRespawn ());
		//}
	}
}
