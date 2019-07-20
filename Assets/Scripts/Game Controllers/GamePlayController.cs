using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, bestScoreText, endScoreText;


    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject gamePausePanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private GameObject[] medals;

    [SerializeField]
    private Text currentScore, bestScore;

    [SerializeField]
    private GameObject[] medalsPausePanel;

    void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
        birds[GameController.instance.GetCurrentBird()].SetActive(true);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;

    }

    public void BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);

        endScoreText.text = "" + score;

        if(score > GameController.instance.GetHighScore())
        {
            Debug.Log("score > getHighScore");
            GameController.instance.SetHighScore(score);
        }

        bestScoreText.text = "" + GameController.instance.GetHighScore();

        medals[0].SetActive(false);
        medals[1].SetActive(false);
        medals[2].SetActive(false);

        if (score < 20)
        {
            medals[0].SetActive(true);
        }else if(score < 40)
        {
            medals[1].SetActive(true);
        }
        else
        {
            medals[2].SetActive(true);
        }
    }

    public void MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }

    public void RestartGameButton()
    {
        Application.LoadLevel("GamePlay");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        currentScore.text = "" + BirdScripts.instance.score;
        bestScore.text = "" + GameController.instance.GetHighScore();
        medalsPausePanel[0].SetActive(false);
        medalsPausePanel[1].SetActive(false);
        medalsPausePanel[2].SetActive(false);

        if (GameController.instance.GetHighScore() < 20)
        {
            medalsPausePanel[0].SetActive(true);
        }
        else if (GameController.instance.GetHighScore() < 40)
        {
            medalsPausePanel[1].SetActive(true);
        }
        else
        {
            medalsPausePanel[2].SetActive(true);
        }

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
    }
}
