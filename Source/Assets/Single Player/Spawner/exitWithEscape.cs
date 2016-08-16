using UnityEngine;
using System.Collections;

public class exitWithEscape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("did this");
            Application.Quit();
        }
	}
}
