using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowFlashing : MonoBehaviour {

    private Text text;

    private bool hide = true;

    private float timeLeft;

    private float flashTime;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hide) {
            timeLeft -= Time.deltaTime;
            text.color = new Color(1f, 1f, 1f, timeLeft);
            if (timeLeft <= 0) {
                hide = false;
            }
        } else {
            timeLeft += Time.deltaTime;
            text.color = new Color(1f, 1f, 1f, timeLeft);
            if (timeLeft >= 1) {
                hide = true;
            }
        }
    }
}
