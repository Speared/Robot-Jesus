using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GUIScript : MonoBehaviour {

	public Text myText;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//myText.text = "Players remaining: " + RespawnInFight.totalLives;
	}
}
