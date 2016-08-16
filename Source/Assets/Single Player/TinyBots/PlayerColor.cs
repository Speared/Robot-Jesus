using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

    public void SetColorFromPlayerNumber(){
        Color newColor;
        MoveScript myMoveScript = GetComponentInChildren<MoveScript>();
        switch (myMoveScript.PlayerNumber)
        {
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
        if (newColor.r < 0.5f)
        {
            newColor.r = 0.5f;
        }
        if (newColor.g < 0.5f)
        {
            newColor.g = 0.5f;
        }
        if (newColor.b < 0.5f)
        {
            newColor.b = 0.5f;
        }
        //newColor.a = 1;
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.color = newColor;
        }
    }

    void SetColorAtRandom()
    {
        Color newColor = new Color(Random.Range(0.5f, 1), Random.Range(0.5f, 1), Random.Range(0.5f, 1), 1);

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.color = newColor;
        }
    }


    // Use this for initialization
    void Start () {
        SetColorAtRandom();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
