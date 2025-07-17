using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
