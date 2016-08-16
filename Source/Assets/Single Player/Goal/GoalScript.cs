using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoalScript : MonoBehaviour {

    float winTimer = 0.5f;
    public string nextLevel = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] cols = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 1f);
        bool foundplayer = false;
        //print(cols.Length);
        foreach (Collider2D c in cols)
        {
            if (c.gameObject.tag == "Player")
            {
                //print("found object" + c.gameObject.name);
                IsPlayerDead dead = c.gameObject.GetComponentInParent<IsPlayerDead>();
                if (dead != null && !dead.dead)
                {
                    foundplayer = true;
                    break;
                }
            }
        }
        if (foundplayer)
        {
            winTimer -= Time.deltaTime;
            
            if (winTimer <= 0)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
        else
        {
            winTimer = 0.5f;
        }
    }


}
