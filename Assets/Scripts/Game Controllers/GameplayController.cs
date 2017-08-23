using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
    //the reason we are creating it this way its so 
    //GamePlayController is a static that can be called from outside
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    [SerializeField]
    private AudioClip fallingRestart, deadHighScore, deadFailure;

    private GameObject camera;

    private void Awake()
    {
        MakeInstance();
        gameOverPanel.SetActive(false);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Use this for initialization
    void Start () {
        Time.timeScale = 0f;
	}
	
	void MakeInstance() {
        if (instance==null) {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore, bool improvedFlag)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        //go to main menu after 3 seconds
        StartCoroutine(GameOverLoadMainMenu(improvedFlag));
    }

    IEnumerator GameOverLoadMainMenu(bool improvedFlag)
    {

        if (improvedFlag)
        {
            AudioSource.PlayClipAtPoint(deadHighScore, camera.transform.position,0.2f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(deadFailure, camera.transform.position,0.3f);
        }
        yield return new WaitForSeconds(4f);
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        AudioSource.PlayClipAtPoint(fallingRestart, camera.transform.position,0.3f);
        yield return new WaitForSeconds(1f);
        SceneFader.instance.LoadLevel("Gameplay");
    }





    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore (int coinScore)
    {
        coinText.text = coinScore.ToString();
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore.ToString();
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }

}
