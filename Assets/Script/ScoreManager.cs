using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int scoreNum;
    private bool coinCollected = false;

    void Start()
    {
        scoreNum = 0;
        scoreText.text = "Score: " + scoreNum;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin") && !coinCollected)
        {
            scoreNum += 10;
            coinCollected = true;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + scoreNum;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCollected = false;
        }
    }
}
