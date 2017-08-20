using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;
    private bool countScore,firstFrame;
    private Vector3 previousPosition;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
        countScore = true;
        firstFrame = true;
	}
	
	// Update is called once per frame
	void Update () {
        CountScore();
	}

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                if (firstFrame)
                {
                    firstFrame = false;
                }
                else
                {
                    scoreCount++;
                    GameplayController.instance.SetScore(scoreCount);
                }

            }
            previousPosition = transform.position;
        } 
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            lifeCount--;
            transform.position = new Vector3(500f, 500f, 0f);
            GameplayController.instance.GameOverShowPanel(scoreCount, coinCount);

        }

        if (target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            lifeCount--;
            transform.position = new Vector3(500f, 500f, 0f);
            GameplayController.instance.GameOverShowPanel(scoreCount, coinCount);
        }

    }

}
