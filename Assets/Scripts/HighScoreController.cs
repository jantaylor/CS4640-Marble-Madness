using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    private string addScoreURL = "http://scores.virtualrain.com/addscore.php?"; //be sure to add a ? to your url
    private string highscoreURL = "http://scores.virtualrain.com/display.php";

    public Text scoresList;

    public Text playerOneScoreText;
 
    void Start()
    {
        StartCoroutine(GetScores());
        playerOneScoreText.text = "FINAL SCORE: " + GameState.Instance.PlayerOneScore.ToString();
    }
 
    // remember to use StartCoroutine when calling this function!
    public IEnumerator PostScores(string name, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = GameState.Instance.Md5Sum(name + score + secretKey);
 
        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
 
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
 
        if (hs_post.error != null)
        {
            Debug.Log("There was an error posting the high score: " + hs_post.error);
        }
    }
 
    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        scoresList.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;
 
        if (hs_get.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            scoresList.text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
}
