using UnityEngine;
using System.Collections;

public class InvisibleEyeUntilGameStarts : MonoBehaviour {

	public SpriteRenderer myEye;

	IEnumerator FadeIn(){
		while (myEye.color.a < 1) {
			Color col = myEye.color;
			col.a += Time.deltaTime * 2;
			myEye.color = col;
			yield return new WaitForSeconds (0.01f);
		}
	}

	public void BegindFadeIn(){
		StartCoroutine (FadeIn ());
	}

	// Use this for initialization
	void Start () {
		Color col = myEye.color;
		col.a = 0;
		myEye.color = col;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
