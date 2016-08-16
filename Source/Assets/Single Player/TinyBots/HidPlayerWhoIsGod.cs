using UnityEngine;
using System.Collections;

public class HidPlayerWhoIsGod : MonoBehaviour {

	MoveScript myScript;
	bool enabled = true;

	Transform[] objectsInChildren;

	// Use this for initialization
	void Start () {
		myScript = GetComponentInChildren<MoveScript> ();
		objectsInChildren = GetComponentsInChildren<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (GetInputToJoin.PlayerWhoIsBoss == myScript.PlayerNumber) {
			
			if (enabled) {

				print("hid player " +  myScript.PlayerNumber);


				foreach (Transform t in objectsInChildren) {
					if (t.gameObject != gameObject) {
						t.gameObject.SetActive (false);
					}
				}
			}
			enabled = false;
		} else {
			if (!enabled) {

				print("unhid player " +  myScript.PlayerNumber);

				print (objectsInChildren.Length );
				foreach (Transform t in objectsInChildren) {
					
					if (t.gameObject != gameObject) {
						t.gameObject.SetActive (true);
					}
				}
				//GetComponent<RespawnInFight> ().RespawnImediate();
			}
			enabled = true;

		}
	}
}
