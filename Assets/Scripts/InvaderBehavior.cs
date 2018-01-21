using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvaderBehavior : MonoBehaviour
{
    public Camera mcamera;
    public Transform Player;
    public float speed = 1f;

    public Spawner spawner;

    public GameObject playerObject;
    public ScoreManager scoreMng;

    public Text scoreText;
    public static int score;

    public AudioClip soundToPlay;
    AudioSource sound;
    public bool isDead = false;

    public MeshRenderer rend;
    public GameObject cubeFrags;

    PlayerState playerState;

    void Awake()
    {
        scoreMng = playerObject.GetComponent<ScoreManager>();
        playerState = playerObject.GetComponent<PlayerState>();
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        sound = GetComponent<AudioSource>();
        rend = gameObject.GetComponent<MeshRenderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCamera();
        Chase();
        StateChecker();
    }


    public void Chase()
    {
        transform.LookAt(Player);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void LookAtCamera()
    {
        transform.LookAt(transform.position + mcamera.transform.rotation * Vector3.forward,
            mcamera.transform.rotation * Vector3.up);
    }

    public void dead()
    {
        speed = 0;
        rend.enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        if (!isDead)
        {
            sound.PlayOneShot(soundToPlay, 1);
            isDead = true;
            
            cubeFrags.SetActive(true);

            spawner.numSpawn -= 1;
            scoreMng.addToScore();


            Destroy(gameObject, 3f);
        }
        
    }

    public void StateChecker()
    {
        if (playerState.isAlive == false)
        {
            speed = 0;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}