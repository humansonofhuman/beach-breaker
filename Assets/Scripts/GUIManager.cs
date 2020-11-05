using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager sharedInstance;
    public Text movesText;
    public Text scoreText;
    private int moveCounter;
    private int score;
    public int MoveCounter
    {
        get
        {
            return moveCounter;
        }
        set
        {
            moveCounter = value;
            movesText.text = $"Moves: {moveCounter}";
        }
    }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = $"Score: {score}";
        }
    }
    void Start()
    {
        if (sharedInstance == null) { sharedInstance = this; }
        else { Destroy(gameObject); }

        Score = 0;
        MoveCounter = 30;
    }

    void Update()
    {

    }
}
