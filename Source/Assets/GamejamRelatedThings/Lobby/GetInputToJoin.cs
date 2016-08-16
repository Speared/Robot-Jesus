using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GetInputToJoin : MonoBehaviour {

	public GameObject godhoodMessage;

	public List<string> PlayersWhoJoined;
	public static string PlayerWhoIsBoss = "1";

	public GameObject smallrobot;
	public GameObject bigrobot;

	public static int numPlayers = 0;

	public Boss_Monster TheMonster;
	public List<Boss_InputController> TheHands;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	IEnumerator SlowDownAndShowMessage(){
		godhoodMessage.SetActive (true);
		Time.timeScale = 0.3f;
		yield return new WaitForSeconds (0.3f);
		Time.timeScale = 1f;
		godhoodMessage.SetActive (false);
	}

	public void DisplayMessage(){
		StartCoroutine (SlowDownAndShowMessage ());
	}

	void OnLevelWasLoaded(int level){
		print ("Players in game" + PlayersWhoJoined.Count);
		numPlayers = PlayersWhoJoined.Count;
		if (level != 0) {
			//RespawnInFight.totalLives = numPlayers * 20;
			foreach (string s in PlayersWhoJoined) {
				if (s == PlayerWhoIsBoss) {
					print (s);
					GameObject boss = Instantiate (bigrobot, GameObject.Find ("Boss").transform.position, Quaternion.identity) as GameObject;
					boss.GetComponent<Boss_Monster> ().PlayerNumber = s;
				} else {
					GameObject player = Instantiate (smallrobot, GameObject.Find ("Player"+s).transform.position, Quaternion.identity) as GameObject;
					player.GetComponentInChildren<MoveScript> ().PlayerNumber = s;
				}
			}
		} else {
			//die enough times in the menu? Fuck you no more lives
			//RespawnInFight.totalLives = int.MaxValue;
			print ("clearing info");
			//make everyone re-enter the game when we go back to the menu
			PlayersWhoJoined.Clear ();
			PlayerWhoIsBoss = "";
		}
	}



	// Update is called once per frame
	void Update () {


		numPlayers = PlayersWhoJoined.Count;

		/*
		//can start with at least one little robot and one boss
		if (PlayersWhoJoined.Count > 1 && Input.GetAxis ("StartButton") != 0) {
			SceneManager.LoadScene ("TheGame");
			//Instantiate (bigrobot);
		}
		*/

		for (int i = 1; i < 8; i++) {
			string PlayerNumber = i.ToString ();
			/*
			if (Input.GetAxis ("A" + PlayerNumber) != 0 ||
			    Input.GetAxis ("B" + PlayerNumber) != 0 ||
			    Input.GetAxis ("Left_Bumper" + PlayerNumber) != 0 ||
			    Input.GetAxis ("Right_Bumper" + PlayerNumber) != 0 ||
			    Input.GetAxis ("Left_Trigger" + PlayerNumber) != 0 ||
			    Input.GetAxis ("Right_Trigger" + PlayerNumber) != 0) {
			    */
			if (Input.GetAxis ("A" + PlayerNumber) != 0){
				//print ("key detected from player: " + PlayerNumber);
			
				if (!PlayersWhoJoined.Contains (PlayerNumber)) {
					if (PlayersWhoJoined.Count == 0) {
						//fade in the boss eye, he lives!
						GameObject.Find("Boss_eye").GetComponent<InvisibleEyeUntilGameStarts>().BegindFadeIn();


						PlayerWhoIsBoss = PlayerNumber;
						TheMonster.PlayerNumber = PlayerNumber;
						//foreach (Boss_InputController controler in TheHands) {
						//	controler.
						//}
					}

					PlayersWhoJoined.Add (PlayerNumber);
					GameObject newBot = Instantiate (smallrobot) as GameObject;
					MoveScript newMove = newBot.GetComponentInChildren<MoveScript> ();
					newMove.PlayerNumber = PlayerNumber;

					//RespawnInLobby myLobbyHelper = newBot.AddComponent<RespawnInLobby> ();
					//myLobbyHelper.spawnMe = smallrobot;


				}


			}
		}
	}
}
