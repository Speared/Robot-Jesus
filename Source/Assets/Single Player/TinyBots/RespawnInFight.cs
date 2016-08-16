using UnityEngine;
using System.Collections;

public class RespawnInFight : MonoBehaviour {
	//unless this gets changed, players share a healhpoop
	//public static int totalLives = 99999;
	bool respawning = false;

	IsPlayerDead amIDead;
	//public GameObject spawnMe;
	// Use this for initialization
	void Start () {
		amIDead = GetComponent<IsPlayerDead> ();
	}

	IEnumerator WaitThenRespawn(){
		//StreakScript.AddKill ();
		yield return new WaitForSeconds (2);
        //this robot's controlls are already shut off, so just tell the spawner no player exists and it'll make a new one
        BotSpawner.currentBot = null;
	}
    /*
	public void RespawnImediate(){
		string PlayerNumber = GetComponentInChildren<MoveScript> ().PlayerNumber;
		Vector3 spawnPos = GameObject.Find ("Player" + PlayerNumber).transform.position;

		GameObject newbot = Instantiate (spawnMe, spawnPos, Quaternion.identity) as GameObject;
		newbot.GetComponentInChildren<MoveScript> ().PlayerNumber = PlayerNumber;
		Destroy (gameObject);
	}
    */
	// Update is called once per frame
	void Update () {
		if (amIDead.dead && !respawning) {
			respawning = true;
			//totalLives--;
			//if (totalLives >= 0) {
				StartCoroutine (WaitThenRespawn ());
			//}


		}
	}
}
