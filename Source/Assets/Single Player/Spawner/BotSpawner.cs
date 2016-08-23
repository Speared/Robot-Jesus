using UnityEngine;
using System.Collections;



public class BotSpawner : MonoBehaviour {

    public GameObject bot;
    public static GameObject currentBot;
    public DebugFollowPlayer changeMeSomeday;
    public delegate void RobotWasSpawned();
    //public event RobotWasSpawned ISpawned;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (currentBot == null)
        {
            GameObject newBot = Instantiate(bot, transform.position, transform.rotation) as GameObject;
            changeMeSomeday.followme = newBot.transform.GetChild(0).gameObject;
            currentBot = newBot;
            //ISpawned();
            
        }
	}
}
