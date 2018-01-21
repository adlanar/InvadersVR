using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //Application.LoadLevel("mainGame");
        SceneManager.LoadScene("mainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void GameOver()
    {

    }

    public void Credits()
    {

    }
}
