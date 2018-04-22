using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    /// <summary>
    /// Create an instance of the game state object in memory
    /// </summary>
    public static GameState Instance;

    /// <summary>
    /// Scene name
    /// </summary>
    [SerializeField]
    private int activeScene;

    /// <summary>
    /// Player's one score default to 0
    /// </summary>
    [SerializeField]
    private int playerOneScore;

    /// <summary>
    /// Player's two score default to 0
    /// </summary>
    [SerializeField]
    private int playerTwoScore;

    /// <summary>
    /// List of Scene Names hard coded
    /// </summary>
    [SerializeField]
    private string[] scenes = new string[] {
        "Menu",
        "Level1",
        "Level2",
        "Level3",
        "Test"
    };

    /// <summary>
    /// Two player game or not
    /// </summary>
    private bool twoPlayers = false;

    /// <summary>
    /// Set and get active scene
    /// </summary>
    public int ActiveScene {
        get { return activeScene; }
        set { activeScene = value; }
    }

    /// <summary>
    /// Set and get player one's score
    /// </summary>
    public int PlayerOneScore {
        get { return playerOneScore; }
        set { playerOneScore = value; }
    }

    /// <summary>
    /// Set and get player one's score
    /// </summary>
    public int PlayerTwoScore {
        get { return playerTwoScore; }
        set { playerTwoScore = value; }
    }

    public bool TwoPlayers {
        get { return twoPlayers; }
        set { twoPlayers = value; }
    }

    /// <summary>
    /// Easier way
    /// </summary>
    public bool CanSubmitHighScore { get; set; }

    public bool playerRespawn { get; set; }

    /// <summary>
    /// On starting the game, singleton state created
    /// </summary>
    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        Clear();
    }

    public void Clear() {
        playerOneScore = 0; // Game always starts out at 0
        playerTwoScore = 0;
        twoPlayers = false;
        playerRespawn = false;
        CanSubmitHighScore = false;
        activeScene = 0; // 0 is menu, 1 is level 1
    }

    /// <summary>
    /// Load previous Scene
    /// </summary>
    public void LoadPreviousScene() {
        // Load the Scene
        if (ActiveScene == 0 || ActiveScene == -1) {
            LoadMenu();
        } else {
            ActiveScene = ActiveScene - 1;
            SceneManager.LoadScene(scenes[ActiveScene]);
        }
    }

    /// <summary>
    /// Load next Scene
    /// </summary>
    public void LoadNextScene() {
        // Load the Scene based on last scene
        if (ActiveScene == scenes.Length - 1) {
            //LoadMenu(); // High Scores Instead?
            GameState.Instance.CanSubmitHighScore = true;
            LoadHighScores();
        } else {
            ActiveScene += 1;
            SceneManager.LoadScene(scenes[ActiveScene]);
        }
    }

    /// <summary>
    /// Load the menu
    /// </summary>
    public void LoadMenu() {
        ActiveScene = 0; // menu scene
        SceneManager.LoadScene(scenes[ActiveScene]);
    }

    public void LoadHowToPlay() {
        ActiveScene = -1; // How to Play Scene
        SceneManager.LoadScene("How To Play");
    }

    /// <summary>
    /// Load the HighScores Scene
    /// </summary>
    public void LoadHighScores() {
        SceneManager.LoadScene("HighScores");
    }
    
    public  string Md5Sum(string strToEncrypt) {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
}
