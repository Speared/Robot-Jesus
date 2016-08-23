using UnityEngine;
using System.Collections;
//in a testimet to my coding skills going down the shitter, this also handles spawn immunity
public class IsPlayerDead : MonoBehaviour {



	public bool dead = false;

	SpriteRenderer[] myRenderers;
	Transform[] myGameObjects;

	bool spawnInvulnerable = true;

	//int bossImmune = 12;
	int normal = 8;
    /*
	IEnumerator Flash(){
		while (spawnInvulnerable) {
			foreach (SpriteRenderer r in myRenderers) {
				if (r.color.a > 0.9) {
					Color boobs = r.color;
					boobs.a = 0.4f;
					r.color = boobs;
				} else {
					Color boobs = r.color;
					boobs.a = 1f;
					r.color = boobs;
				}
			}
			yield return new WaitForSeconds (0.2f);
		}
		foreach (SpriteRenderer r in myRenderers) {
			Color boobs = r.color;
			boobs.a = 1f;
			r.color = boobs;
		}
	}

	IEnumerator BeInvinclible(){
		spawnInvulnerable = true;
		yield return new WaitForSeconds (2);
		spawnInvulnerable = false;
		foreach (Transform t in myGameObjects) {
			t.gameObject.layer = normal;
		}
	}

	void Update(){
		//print (gameObject.layer);
	}

	void Start(){
		myRenderers = GetComponentsInChildren<SpriteRenderer> ();
		myGameObjects = GetComponentsInChildren<Transform> ();

		foreach (Transform t in myGameObjects) {
			t.gameObject.layer = bossImmune;
		}

		StartCoroutine (BeInvinclible ());
		StartCoroutine (Flash ());
	}
    */
}
