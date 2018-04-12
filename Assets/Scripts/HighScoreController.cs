using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    public string addScoreURL = "http://localhost:1337/api/scores";
    public string highscoreURL = "http://localhost:1337/api/scores";

    void Start() {
        StartCoroutine(GetScores());
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string name, int score) {
        //This connects to a server side nodejs api that will add the name and score to the API.
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(addScoreURL);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null) {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    // Get the scores from the API to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores() {
        gameObject.GetComponent<GUIText>().text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null) {
            print("There was an error getting the high score: " + hs_get.error);
        } else {
            gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
}
