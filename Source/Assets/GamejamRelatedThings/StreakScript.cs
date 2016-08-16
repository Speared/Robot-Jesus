using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StreakScript : MonoBehaviour {

	public Text myText1;
	public Text myText2;

	public static int largestStreak = 0;
	public static int currentStreak = 0;
	static string bossWithBestStreak;

	// Use this for initialization
	void Start () {
	
	}

	public static void AddKill(){
		currentStreak++;
		if (currentStreak > largestStreak) {
			largestStreak = currentStreak;
			bossWithBestStreak = GetInputToJoin.PlayerWhoIsBoss;
		}
	}

	public static void NewBossDecided(){
		currentStreak = 0;
	}


	Color SetTextColor(string player){
		Color newColor;
		switch (player) {
		case "1":
			newColor = Color.red;
			break;
		case "2":
			newColor = Color.green;
			break;
		case "3":
			newColor = Color.yellow;
			break;
		case "4":
			newColor = Color.blue;
			break;
		case "5":
			newColor = Color.white;
			break;
		case "6":
			newColor = Color.magenta;
			break;
		case "7":
			newColor = Color.cyan;
			break;
		case "8":
			newColor = Color.black;
			break;
		default:
			newColor = Color.clear;
			break;
		}
		if (newColor.r < 0.5f) {
			newColor.r = 0.5f;
		}
		if (newColor.g < 0.5f) {
			newColor.g = 0.5f;
		}
		if (newColor.b < 0.5f) {
			newColor.b = 0.5f;
		}

		return newColor;
	}

	// Update is called once per frame
	void Update () {
		myText1.color = SetTextColor(GetInputToJoin.PlayerWhoIsBoss);
		myText1.text = ("Current Boss: Player " + GetInputToJoin.PlayerWhoIsBoss + "'s Streak: " + currentStreak);
		myText2.color = SetTextColor (bossWithBestStreak);
		myText2.text = ("Best Streak: Player " + bossWithBestStreak + "'s Streak: " + largestStreak);
	}
		
}
