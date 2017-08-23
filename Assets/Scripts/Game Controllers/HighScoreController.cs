using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

	// Use this for initialization
	void Start () {
        SetScoreBasedOnDifficulty();
	}

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }


    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            GamePreferences.SetEasyDifficultyHighScore(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            SetScore(GamePreferences.GetEasyDifficultyHighScore(),
                GamePreferences.GetEasyDifficultyHighScore());
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            GamePreferences.SetMediumDifficultyHighScore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            SetScore(GamePreferences.GetMediumDifficultyHighScore(),
                GamePreferences.GetMediumDifficultyHighScore());
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            GamePreferences.SetHardDifficultyHighScore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            SetScore(GamePreferences.GetHardDifficultyHighScore(),
                GamePreferences.GetHardDifficultyHighScore());
        }

        
    }

}
