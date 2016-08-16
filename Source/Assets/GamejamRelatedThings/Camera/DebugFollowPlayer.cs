using UnityEngine;
using System.Collections;

public class DebugFollowPlayer : PlayerScriptBase {
	public GameObject followme;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (followme == null) {
			return;
		}

		Vector3 desieredPos = followme.transform.position;
		desieredPos.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, desieredPos, 0.75f);
	}
}
