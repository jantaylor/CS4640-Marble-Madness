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
        if (nameInput.text.Length == 3 && !postedScore && GameState.Instance.CanSubmitHighScore) {
            postedScore = true;
            nameInput.readOnly = true;
            nameInput.customCaretColor = true;
            nameInput.caretColor = new Color(1f, 1f, 1f, 0f);
            StartCoroutine(highScoreController.PostScores(nameInput.text.ToUpper(), GameState.Instance.PlayerOneScore));            
        }
    }
}
