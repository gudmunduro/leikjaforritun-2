using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    public GameObject player;
    public GameObject opponent;
    public GameController gameController;

    private float playerLapTime;
    private float opponentLapTime;

	void Start () {
        Debug.Log(this.transform.position.x);
        Debug.Log(this.transform.position.y);
        Debug.Log("Player");
	}
	
	void Update () {
		if (player.transform.position.x < this.transform.position.x + 10 && player.transform.position.x > this.transform.position.x && player.transform.position.y < this.transform.position.y + 50 && player.transform.position.y > this.transform.position.y - 10)
        {
            OnCollision(player);
        }

        if (opponent.transform.position.x < this.transform.position.x + 10 && opponent.transform.position.x > this.transform.position.x && opponent.transform.position.y < this.transform.position.y + 50 && opponent.transform.position.y > this.transform.position.y - 10)
        {
            OnCollision(player);
        }
    }

    private void OnCollision(GameObject with)
    {
        if (with == player)
        {
            if (playerLapTime != 0 && playerLapTime + 10.0f > Time.time) return;
            playerLapTime = Time.time;

            gameController.OnFinishLineEnter("player");
        }
        else if (with == opponent)
        {
            if (opponentLapTime != 0 && opponentLapTime + 10.0f > Time.time) return;
            opponentLapTime = Time.time;

            gameController.OnFinishLineEnter("opponent");
        }
    }

}
