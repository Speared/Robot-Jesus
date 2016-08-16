using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GodhoodScript : MonoBehaviour {

	public List<GameObject> numbers;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	void OnEnable(){
		foreach (GameObject g in numbers) {
			if (g.name == GetInputToJoin.PlayerWhoIsBoss) {
				g.SetActive (true);
			} else {
				g.SetActive (false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = startPos + Random.insideUnitSphere / 3;
	}
}
