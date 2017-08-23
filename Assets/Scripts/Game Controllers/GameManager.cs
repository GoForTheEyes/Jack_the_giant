using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    private AudioSource audioSource;

    private void Awake()
    {
        MakeSingleton();
    }

    // Use this for initialization
    void Start () {
        InitializeVariables();
        audioSource = GetComponent<AudioSource>();
	}

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    private void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            } else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);
            }
        }
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);
            //Default is Medium Diff
            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);
            //Default is no music
            GamePreferences.SetMusicState(0);
            ///Creating key with random value so it doesn't get in if condition
            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    //checks if life>0 to restart level
    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore<0)
        {
            bool improvedFlag = ImprovedScore(score, coinScore);
            UpdateScore(score, coinScore);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore, improvedFlag);

        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GameplayController.instance.PlayerDiedRestartTheGame();

        }
    }

    private static void UpdateScore(int score, int coinScore)
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            int highScore = GamePreferences.GetEasyDifficultyHighScore();
            int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

            if (highScore < score) GamePreferences.SetEasyDifficultyHighScore(score);
            if (coinHighScore < coinScore) GamePreferences.SetEasyDifficultyCoinScore(coinScore);

        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            int highScore = GamePreferences.GetMediumDifficultyHighScore();
            int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

            if (highScore < score) GamePreferences.SetMediumDifficultyHighScore(score);
            if (coinHighScore < coinScore) GamePreferences.SetMediumDifficultyCoinScore(coinScore);
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            int highScore = GamePreferences.GetHardDifficultyHighScore();
            int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

            if (highScore < score) GamePreferences.SetHardDifficultyHighScore(score);
            if (coinHighScore < coinScore) GamePreferences.SetHardDifficultyCoinScore(coinScore);
        }
    }

    public static bool ImprovedScore(int score, int coinScore)
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            int highScore = GamePreferences.GetEasyDifficultyHighScore();
            int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();
            return (highScore < score) || (coinHighScore < coinScore);

        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            int highScore = GamePreferences.GetMediumDifficultyHighScore();
            int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();
            Debug.Log((highScore < score) || (coinHighScore < coinScore));
            return (highScore < score) || (coinHighScore < coinScore);
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            int highScore = GamePreferences.GetHardDifficultyHighScore();
            int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();
            return (highScore < score) || (coinHighScore < coinScore);
        }
        return false;
    }

}
