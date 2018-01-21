using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public bool isAlive;

    // Use this for initialization
    void Start()
    {
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        isAlive = false;
        Debug.Log("GAME OVER");
        if (!isAlive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}