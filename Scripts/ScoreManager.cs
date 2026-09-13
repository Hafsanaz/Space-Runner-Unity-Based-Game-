using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private float score;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "0";
    }
}
