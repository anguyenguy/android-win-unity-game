using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private const string HIGH_SCORE = "High Score";

    [SerializeField]
    private GameObject[] birds;

    private int selected_bird = 0;

    
    void Awake()
    {
        MakeSingleInstance();
        IsGameStartForTheFirstTime();
        birds[selected_bird].SetActive(true);
    }

    void IsGameStartForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFirstTime", 0);
        }
    }

    void MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void changeBird()
    {
        selected_bird++;
        if (selected_bird > 2)
        {
            selected_bird = 0;
        }
        birds[0].SetActive(false);
        birds[1].SetActive(false);
        birds[2].SetActive(false);
        birds[selected_bird].SetActive(true);
    }

    public int GetCurrentBird()
    {
        return selected_bird;
    }

}
