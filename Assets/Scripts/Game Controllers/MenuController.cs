using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    void Start()
    {
      //  birds[GameController.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();
    }

    void CheckIfBirdsAreUnlocked()
    {
        //if (GameController.instance.IsRedBirdUnlocked() == 1)
        //{
        //    isRedBirdUnlocked = true;
        //}

        //if (GameController.instance.IsGreenBirdUnlocked() == 1)
        //{
        //    isGreenBirdUnlocked = true;
        //}
    }

    public void PlayGame()
    {
        Debug.Log("PlayGame()");
        SceneFader.instance.FadeIn("GamePlay");
    }

    public void ChangeBird()
    {
        //if (GameController.instance.GetSelectedBird() == 0)
        //{
        //    GameController.instance.SetSelectedBird(1);
        //    UnSetActiveForAllBird();
        //    birds[GameController.instance.GetSelectedBird()].SetActive(true);
        //}
        //else if (GameController.instance.GetSelectedBird() == 1)
        //{
        //    GameController.instance.SetSelectedBird(2);
        //    UnSetActiveForAllBird();
        //    birds[GameController.instance.GetSelectedBird()].SetActive(true);
        //}
        //else if (GameController.instance.GetSelectedBird() == 2)
        //{
        //    GameController.instance.SetSelectedBird(0);
        //    UnSetActiveForAllBird();
        //    birds[GameController.instance.GetSelectedBird()].SetActive(true);
        //}
    }

    private void UnSetActiveForAllBird()
    {
        birds[0].SetActive(false);
        birds[1].SetActive(false);
        birds[2].SetActive(false);
    }
}
