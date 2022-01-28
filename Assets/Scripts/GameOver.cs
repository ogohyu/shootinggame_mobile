using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text currentScoreUI;
    public Text bestScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        int currentScore = ScoreManager.Instance.Score;
        currentScoreUI.text = "내 점수 : " + currentScore;

        int bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
