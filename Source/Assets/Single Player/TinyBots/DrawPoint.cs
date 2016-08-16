using UnityEngine;
using System.Collections;

public class DrawPoint : MonoBehaviour {
	void OnDrawGizmos() {
		Gizmos.color = Color.white;
		Gizmos.DrawSphere (transform.position, 0.1f);
	}
}
