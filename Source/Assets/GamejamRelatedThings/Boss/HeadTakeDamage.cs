using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HeadTakeDamage : MonoBehaviour {

	public GameObject healthbar;
	float health = 1;
	float damageTick = 0.05f;
	Color myColor;
	public SpriteRenderer mySpriteRenderer;



	IEnumerator FlashRed(){
		mySpriteRenderer.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		mySpriteRenderer.color = myColor;
	}

	public bool HurtMe(){
		StartCoroutine (FlashRed ());
		print ("numplayers: " + GetInputToJoin.numPlayers);

		health -= damageTick / GetInputToJoin.numPlayers;
		if (health > 0) {
			return false;
		} else {
			StreakScript.NewBossDecided ();
			health = 1;
			return true;
		}
	}

	// Use this for initialization
	void Start () {
		//mySpriteRenderer = GetComponent<SpriteRenderer> ();
		myColor = mySpriteRenderer.color;
	}

	IEnumerable EndGame(){
		//todo: play explosions here
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene ("Lobby");
	}

	// Update is called once per frame
	void Update () {
		if (health > 0) {
			Vector3 scale = healthbar.transform.localScale;
			scale.x = health;
			healthbar.transform.localScale = scale;
		} else {
			//todo: use endgame function to be fancier about this
			//SceneManager.LoadScene ("Lobby");
		}


	}
}
