using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject scoreBoard;
    public GameObject startMenu;
    public Button startButton;
    public Text scoreText1;
    public Text scoreText2;
    public int lapsForPlayer;
    public int lapsForOpponent;

    public float timeForFinisher;

	void Start () {
        scoreBoard.SetActive(false);

        lapsForPlayer = 0;
        lapsForOpponent = 0;

        startButton.onClick.AddListener(() =>
        {
            StartGame();
        });
    }
	
	void Update () {
		
	}

    private void ShowScoreBoard(string firstPlace, string secondPlace)
    {
        scoreText1.text = firstPlace + " - " + timeForFinisher.ToString();
        scoreText2.text = secondPlace + " - " + "DNF";

        scoreBoard.SetActive(true);
    }

    private void StartGame()
    {
        startMenu.SetActive(false);
    }

    public void OnFinishLineEnter(string car)
    {
        switch (car)
        {
            case "player":
                {
                    lapsForPlayer++;
                    timeForFinisher = Time.time;
                    if (lapsForPlayer == 1)
                    {
                        ShowScoreBoard("Player", "Opponent");
                    }
                    break;
                }
            case "opponent":
                {
                    lapsForOpponent++;
                    timeForFinisher = Time.time;
                    if (lapsForOpponent == 1)
                    {
                        ShowScoreBoard("Opponent", "Player");
                    }
                    break;
                }
        }
    }
}
