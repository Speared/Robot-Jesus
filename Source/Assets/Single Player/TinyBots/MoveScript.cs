using UnityEngine;
using System.Collections;

public class MoveScript : PlayerScriptBase {

	public string PlayerNumber = "1";

	public Rigidbody2D body;

    public bool leftHandMode = false;
    string leftSuffix = "";
    string rightSuffix = "";

	GroundChecker myGroundChecker;
	Rigidbody2D myRigidBody;
	float speed = 1f;
	float airspeed = 0.5f;
	float maxSpeed = 10;
    float maxAirSpeed = 6;
	int jumpsLeft = 0;
	int maxJumps = 1;
    float suctionforce = 0.2f;
    float timeToReconsiderGroundCheck = 0.1f;

    IsPlayerDead amIdead;

	float jumpForce = 15000;
	bool jumpAxisInUse = false;

	public Animator headAnimator;
	public Animator treadsAnimator;

    bool touchedGound = false;
    bool reversedControlls = false;

    Vector2 desieredRot;
    bool seekDesieredRot = false;

    // Use this for initialization
    void Start () {
		myGroundChecker = transform.parent.GetComponentInChildren<GroundChecker> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
        amIdead = GetComponentInParent<IsPlayerDead>();

        if (leftHandMode)
        {
            leftSuffix = "_Right";
        }
        else
        {
            rightSuffix = "_Right";
        }
	}

	void CapMaxSpeed(Rigidbody2D body){
		
		//get portion of vector going down
		float downwardsSpeed = Vector2.Dot(body.velocity, Vector2.down);
		//print (downwardsSpeed);
		//remove the downward speed from the vector, we don't want to change it
		//do nothing if the player is moving up
		Vector2 speedWithoutDown = body.velocity;
		if (downwardsSpeed > 0) {
			speedWithoutDown = body.velocity - Vector2.down * downwardsSpeed;
		} else {
			downwardsSpeed = 0;
		}

		if (speedWithoutDown.magnitude > maxSpeed) {
			speedWithoutDown /= speedWithoutDown.magnitude;
			speedWithoutDown *= maxSpeed;
		}
		body.velocity = speedWithoutDown + Vector2.down * downwardsSpeed;


	}


	// Update is called once per frame
	void FixedUpdate () {
        //print(reversedControlls);

        float xMovement = Input.GetAxis ("Horizontal"+leftSuffix+PlayerNumber);
        float yMovement = Input.GetAxis("Vertical"+leftSuffix+ PlayerNumber);
		if (xMovement != 0) {
			treadsAnimator.enabled = true;
			if (xMovement < 0) {
				headAnimator.SetBool ("Left", true);
			} else {
				headAnimator.SetBool ("Left", false);
			}
		} else {
			treadsAnimator.enabled = false;
		}

        float jumpButtons = 0;




        //get if our treads are somewhat level
        //float angleOfTreads = Vector2.Dot(transform.right, Vector2.up);
        //if(angleOfTreads > 

        //on the ground move reletive to the treads

        Vector2 right2d = new Vector2(transform.right.x, transform.right.y);

        //Debug.Log (xMovement);
        if (myGroundChecker.passedGroundChecks > 0 ) {

            

            Vector3 rightAbs = new Vector3(Mathf.Abs(right2d.x), Mathf.Abs(right2d.y), 0);
            Vector3 upAbs = new Vector3(Mathf.Abs(transform.up.x), Mathf.Abs(transform.up.y), 0);

            //when on a wall, if the up/down axis is larger than the left/right axis use its input instead
            if (Mathf.Abs(yMovement) > Mathf.Abs(xMovement) && Vector3.Dot(rightAbs, Vector3.up) > Vector3.Dot(rightAbs, Vector3.right))
            {
                if (Vector3.Dot(transform.up, Vector3.right) > 0)
                {
                    xMovement = -yMovement;
                }
                else
                {
                    xMovement = yMovement;
                }
            }

            float backwardsPressed = Vector2.Dot(myRigidBody.velocity, new Vector2(-xMovement, 0));

            Vector2 moveVec = right2d * speed * xMovement;
            //print("on the ground " + myGroundChecker.passedGroundChecks);


            //flip controlls if right in world space and right in local space are oposit directions

            if (Vector3.Dot(transform.right, Vector3.right) < -0.9f && !touchedGound)
            {
                //print("reversed");
                //print(Vector3.Dot(transform.right, Vector3.right));
                reversedControlls = true;
            }
            //timeToReconsiderGroundCheck = 0.15f;

            //only reverse controlls at all if upside down
            if (Vector3.Dot(transform.up, Vector3.up) > 0)
            {
                //print("standing up so no reverse");
                reversedControlls = false;
            }

            if (reversedControlls)
            {
                moveVec *= -1;
            }

            
            if (myRigidBody.velocity.magnitude > maxSpeed)
            {
                float moveVecInMovingDir = Vector2.Dot(myRigidBody.velocity.normalized, moveVec);

                if (moveVecInMovingDir > 0)
                {

                    moveVec -= moveVec.normalized * moveVecInMovingDir;
                }
            }
            //add some downwards force to grip walls better. only happens when pressing forwards
            if (backwardsPressed < 0)
            {
                moveVec -= new Vector2(transform.up.x, transform.up.y) * suctionforce;
                
            }
            else if(backwardsPressed == 0)
            {
                //unreverse controls when hitting backwards or not moving as well
                //print("went backwords");
                reversedControlls = false;
            }

            myRigidBody.velocity += moveVec;


		//in the air move reletive to world space
		} else {

            Vector2 moveVec = Vector2.zero;
            Vector3 rightAbs = new Vector3(Mathf.Abs(right2d.x), Mathf.Abs(right2d.y), 0);
            Vector3 upAbs = new Vector3(Mathf.Abs(transform.up.x), Mathf.Abs(transform.up.y), 0);
            if (myGroundChecker.passedGroundChecksFurtherDown > 1 && Mathf.Abs(yMovement) > Mathf.Abs(xMovement) && Vector3.Dot(rightAbs, Vector3.up) > Vector3.Dot(rightAbs, Vector3.right)) {
                moveVec = Vector2.right * airspeed * -yMovement;
            }
            else
            {
                moveVec = Vector2.right * airspeed * xMovement;
            }
            //Vector2 moveVec = Vector2.right * airspeed * xMovement;
            /*
            //cap horizontal speed
            //CapMaxSpeed (myRigidBody);
            //CapMaxSpeed (body);
            */
            if (myRigidBody.velocity.magnitude > maxAirSpeed)
            {
                float moveVecInMovingDir = Vector2.Dot(body.velocity.normalized, moveVec);

                if (moveVecInMovingDir > 0)
                {
                    //print("airmove");
                    moveVec -= moveVec.normalized * moveVecInMovingDir;

                }
            }
            
            myRigidBody.velocity += moveVec;

            //airbreak
            if (Input.GetAxis("B" + PlayerNumber) != 0)
            {
                myRigidBody.angularVelocity -= myRigidBody.angularVelocity * 0.50f;
            }

            //rotate in the air based on arrow keys
            if (Input.GetAxis("Horizontal"+rightSuffix+ PlayerNumber) != 0 || Input.GetAxis("Vertical"+rightSuffix + PlayerNumber) != 0)
            {
                desieredRot = new Vector2(Input.GetAxis("Horizontal"+rightSuffix + PlayerNumber) * -1, Input.GetAxis("Vertical"+rightSuffix + PlayerNumber) * -1);
                seekDesieredRot = true;
            }
            if (seekDesieredRot)
            {
                Vector2 up = new Vector2(transform.up.x, transform.up.y);

                if (Vector2.Angle(up, desieredRot) > 10)
                {
                    //keep using out current rotation to get where we want to go if we're spinning fast enough
                    if (Mathf.Abs(myRigidBody.angularVelocity) > 50)
                    {
                        if (Mathf.Abs(myRigidBody.angularVelocity) < 500)
                        {
                            myRigidBody.angularVelocity += myRigidBody.angularVelocity * 0.25f;
                        }
                    }
                    else
                    {
                        //otherwise add rotation to the shortest direction to the desiered vector
                        Vector3 cross = Vector3.Cross(desieredRot, transform.up);
                        if (cross.z < 0)
                        {
                            myRigidBody.angularVelocity += 500f;
                        }
                        else
                        {
                            myRigidBody.angularVelocity -= 500f;
                        }
                    }
                }
                else
                {
                    
                    myRigidBody.angularVelocity -= myRigidBody.angularVelocity * 0.50f;
                    if (myRigidBody.angularVelocity < 1)
                    {
                        myRigidBody.angularVelocity = 0;
                        seekDesieredRot = false;
                    }
                }
            }
                
            
        }

		
		if (Input.GetAxis ("A"+PlayerNumber) != 0 ||
			Input.GetAxis ("Left_Bumper"+PlayerNumber) != 0 ||
			Input.GetAxis ("Right_Bumper"+PlayerNumber) != 0 ||
			Input.GetAxis ("Left_Trigger"+PlayerNumber) != 0 ||
			Input.GetAxis ("Right_Trigger"+PlayerNumber) != 0) {

			jumpButtons = 1;

            
        }

		//you can only jump if at least one tread is on the ground
		if(jumpButtons != 0 && !jumpAxisInUse && myGroundChecker.passedGroundChecks > 0){

            jumpAxisInUse = true;
			if (jumpsLeft > 0) {
				jumpsLeft--;
				myRigidBody.AddForce(transform.up * jumpForce);
			}
		}
		if (jumpButtons == 0) {
			//half upward vertical speed
			if (jumpAxisInUse) {
				float upwardsSpeed = Vector2.Dot(body.velocity, Vector2.up);
				if (upwardsSpeed > 0) {
					myRigidBody.velocity -= Vector2.up * upwardsSpeed / 2f;
				}
			}
			jumpAxisInUse = false;
		}
        if (myGroundChecker.passedGroundChecks > 0)
        {
            touchedGound = true;
        }
        else if (myGroundChecker.passedGroundChecksFurtherDown == 0)
        {
            reversedControlls = false;
            touchedGound = false;
        }
	}
	//pop up the treads a tiny bit on collision enter, to hopefully scale cliffs better
	void OnCollisionEnter2D(Collision2D coll) {
        //TODO: fixme
        /*
        Vector2 rightIn2d = new Vector2(transform.right.x, transform.right.y);
        Vector2 posIn2d = new Vector2(transform.position.x, transform.position.y);
        Vector2 averageContactPoint = Vector2.zero;
        foreach (ContactPoint2D p in coll.contacts)
        {
            averageContactPoint += p.point;
        }
        averageContactPoint /= coll.contacts.Length;

        float collisionDist = Vector2.Dot(averageContactPoint - posIn2d, rightIn2d);

        print(collisionDist);
        if (Mathf.Abs(collisionDist) > 0.1f && !amIdead.dead)
        {
            print(Mathf.Abs(collisionDist));
            float launchforce = 5000;
            if (myGroundChecker.passedGroundChecks > 1)
            {
                launchforce = 8750;
            }
            myRigidBody.AddForceAtPosition((posIn2d - averageContactPoint) * launchforce, averageContactPoint);
        }
        */
		jumpsLeft = maxJumps;
	}
}
