using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

    // Use this for initialization
    void Start () {
        CheckToPlayMusic();
    }
	
    void CheckToPlayMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void HighscoreMenu()
    {
        SceneManager.LoadScene("Highscore Scene");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }

}
