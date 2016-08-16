using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {

    public float cycle = 1;
    public float delay = 0;
    bool cruchNow = true;
    public float crushForce = 10;
    public Rigidbody2D myRigidBody;
    public bool resetOnPlayerDeath = false;
    Vector3 startPos;
    

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        if (cycle < 0.001f)
        {
            cycle = 0.001f;
        }
        StartCoroutine(Crush());
        if (resetOnPlayerDeath)
        {
            //BotSpawner
        }
	}

    void OnDestroy()
    {
        if (resetOnPlayerDeath)
        {

        }
    }

    void HandlePlayerDeath()
    {

    }

    IEnumerator Crush()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            if (cruchNow)
            {
                myRigidBody.velocity -= new Vector2(transform.up.x, transform.up.y) * crushForce;
            }
            else
            {
                myRigidBody.velocity += new Vector2(transform.up.x, transform.up.y) * crushForce;
            }
            cruchNow = !cruchNow;
            yield return new WaitForSeconds(cycle);
        }
    }

	// Update is called once per frame
	void Update () {
        
	}
}
