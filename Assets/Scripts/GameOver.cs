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
        currentScoreUI.text = "�� ���� : " + currentScore;

        int bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "�ְ����� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
