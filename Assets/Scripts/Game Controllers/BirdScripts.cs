using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScripts : MonoBehaviour
{
    public static BirdScripts instance;

    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    public float flag = 0;
    public int score = 0;

    private GameObject groundCollector;
    private GameObject bgCollector;
    private GameObject pipeCollector;

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Awake()
    {
        //Debug.Log("On awake");
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        groundCollector = GameObject.Find("Collector Ground");
        bgCollector = GameObject.Find("Collector BG");
        pipeCollector = GameObject.Find("Collector Pipe");
    }

    void FixedUpdate()
    {
        BirdMoveMent();
    }

    void BirdMoveMent()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if (myBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, myBody.velocity .y/ 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
            if(target.tag == "PipeHolder")
        {
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }

    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(groundCollector);
                Destroy(bgCollector);
                Destroy(pipeCollector);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
                GamePlayController.instance.BirdDiedShowPanel(score);
            }
        }
    }

}
