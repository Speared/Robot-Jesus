using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GroundChecker : PlayerScriptBase {

	//public GameObject leftCheck;
	//public GameObject rightCheck;
	//public GameObject centerCheck;

	public List<GameObject> checkers;

	public int passedGroundChecks{ get; private set; }
    public int passedGroundChecksFurtherDown { get; private set; } 

    public Rigidbody2D[] myRigidBodies;
	int dosntcolidewith = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		passedGroundChecks = 0;
		foreach (GameObject checker in checkers) {
			bool foundClimbableObject = false;
			Collider2D[] foundColliders = Physics2D.OverlapCircleAll (checker.transform.position, 0.1f);
			foreach (Collider2D found in foundColliders) {
				if (found.gameObject.layer != dosntcolidewith) {
                    //print (found.gameObject.name + " " + found.gameObject.layer);
                    //print(found.gameObject.layer);
                    foundClimbableObject = true;
					break;
				}
			}
			if (foundClimbableObject) {
                
                passedGroundChecks++;
			}
		}

        passedGroundChecksFurtherDown = 0;
        foreach (GameObject checker in checkers)
        {
            bool foundClimbableObject = false;
            Collider2D[] foundColliders = Physics2D.OverlapCircleAll(checker.transform.position + -transform.up * 0.25f, 0.1f);
            foreach (Collider2D found in foundColliders)
            {
                if (found.gameObject.layer != dosntcolidewith)
                {
                    //print (found.gameObject.name + " " + found.gameObject.layer);
                    //print(found.gameObject.layer);
                    foundClimbableObject = true;
                    break;
                }
            }
            if (foundClimbableObject)
            {

                passedGroundChecksFurtherDown++;
            }
        }

    }
}
