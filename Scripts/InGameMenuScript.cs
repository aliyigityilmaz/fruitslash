using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuScript : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;


    public Text lostScreenScore;
    public Text HighScoreText;
    public GameObject stopButton;

    private int score;
    private int HighScore;
    string highScorekey;

    private GameObject mouse;
    [SerializeField]
    private GameObject dropZone;
    private int Health;

    public GameObject stopMenu;

    public GameObject loseMenu;
    void Start()
    {
        stopButton.SetActive(true);
        loseMenu.SetActive(false);
        stopMenu.SetActive(false);
        Time.timeScale = 1.0f;
        mouse = GameObject.FindWithTag("Player");

        HighScore = PlayerPrefs.GetInt(highScorekey, 0);
    }
    void Update()
    {
        score = mouse.GetComponent<MouseScript>().Score;
        scoreText.text = score.ToString();

        Health = dropZone.GetComponent<DropZone>().Health;
        healthText.text = Health.ToString();
        lostScreenScore.text = "Score: " + scoreText.text;
        if (score > HighScore)
        {
            PlayerPrefs.SetInt(highScorekey, score);
            PlayerPrefs.Save();

        }
        HighScoreText.text = "HighScore: " + HighScore.ToString();
        if (Health <= 0)
        {
            Time.timeScale = 0f;
            loseMenu.SetActive(true);
            stopButton.SetActive(false);
        }
    }

    public void StopGame()
    {
        stopMenu.SetActive(true);
        stopButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        stopMenu.SetActive(false);
        stopButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
