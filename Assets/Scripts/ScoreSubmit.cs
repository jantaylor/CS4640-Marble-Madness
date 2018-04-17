using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSubmit : MonoBehaviour {

    public InputField nameInput;

    public HighScoreController highScoreController;

    public bool postedScore = false;

	// Use this for initialization
	void Start () {
        nameInput = GetComponent<InputField>();
        highScoreController = FindObjectOfType<HighScoreController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (nameInput.text.Length == 3 && !postedScore) {
            Debug.Log("Lengh of name: 3");
            PostScores(nameInput.text.ToUpper(), GameState.Instance.PlayerOneScore);
            postedScore = true;
        }
    }

    public void PostScores(string name, int score) {
        Debug.Log("Posting Score: " + name + " - " + score.ToString());
        highScoreController.PostScores(name, score);
    }
}
