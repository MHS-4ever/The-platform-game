using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{

    public GameObject L2Lock;
    public GameObject L3Lock;

    public GameObject playGamePanel;
    public GameObject levelSelectorPanel;

    public int levelWins;

    // Start is called before the first frame update
    void Start()
    {
        levelWins = PlayerPrefs.GetInt("levelWon");
    }

    // Update is called once per frame
    void Update()
    {
        if (levelWins == 0)
        {
            L2Lock.SetActive(true);
            L3Lock.SetActive(true);
        }
        if (levelWins == 1)
        {
            L2Lock.SetActive(false);
            L3Lock.SetActive(true);
        }
        if (levelWins == 2)
        {
            L2Lock.SetActive(true);
            L3Lock.SetActive(true);
        }
    }

    public void playGame ()
    {
        playGamePanel.SetActive(false);
        levelSelectorPanel.SetActive(true);
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
}
