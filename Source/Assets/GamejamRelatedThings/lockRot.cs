using UnityEngine;
using System.Collections;

public class lockRot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (Vector3.forward);
	}
}
