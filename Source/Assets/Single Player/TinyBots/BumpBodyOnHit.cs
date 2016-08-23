using UnityEngine;
using System.Collections;

public class BumpBodyOnHit : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    public IsPlayerDead amIDead;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!amIDead.dead)
        {
            print("did this");
            Vector2 force = new Vector2(transform.position.x, transform.position.y) - coll.contacts[0].point;
            myRigidbody.AddForceAtPosition(force * 50, coll.contacts[0].point);
        }
    }
}