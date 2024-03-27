using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }

    public void restartButtonL1()
    {
        SceneManager.LoadScene(1);
    }

    public void restartButtonL2()
    {
        SceneManager.LoadScene(2);
    }

    public void restartButtonL3()
    {
        SceneManager.LoadScene(3);
    }

}
