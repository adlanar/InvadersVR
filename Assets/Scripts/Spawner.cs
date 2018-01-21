using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO
//use invoke repeating to make delays
//make enemies approach to player
//score board

public class Spawner : MonoBehaviour {
    
    public GameObject[] spawnerPoints;

    public int numSpawn = 0;
    public int maxSpawn = 6;

    GameObject[] invadersArray;

    public AudioClip soundToPlay;
    AudioSource sound;

    public GameObject readyText;
    public GameObject gameOverText;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();

        invadersArray = new GameObject[3];
        invadersArray[0] = transform.Find("invader1").gameObject;
        invadersArray[1] = transform.Find("invader2").gameObject;
        invadersArray[2] = transform.Find("invader3").gameObject;

        StartCoroutine("GetReady");
    }
	
	// Update is called once per frame
	void Update () {
        //if(numSpawn > maxSpawn)
        //{
         //   CancelInvoke("SpawnInvader");
       // }
    }

    void SpawnInvader()
    {
        //for (int i = numSpawn; i <= maxSpawn; i++)
        ///{
        if (numSpawn < maxSpawn)
        {
            GameObject invader = Instantiate(invadersArray[UnityEngine.Random.Range(0, 3)],
            spawnerPoints[UnityEngine.Random.Range(0, spawnerPoints.Length - 1)].transform.position,
            Quaternion.identity) as GameObject;

            invader.SetActive(true);
            numSpawn++;
            Debug.Log("numSpawn: " + numSpawn + ", pos:" + invader.transform.position + " time: " + Time.time);
        }
       // }
    }

    IEnumerator GetReady()
    {
        Debug.Log("GET READY!");
        sound.PlayOneShot(soundToPlay, 1);
        yield return new WaitForSeconds(3.5f);
        Destroy(readyText);

        InvokeRepeating("SpawnInvader", 1, UnityEngine.Random.Range(1,3));
    }

	}

