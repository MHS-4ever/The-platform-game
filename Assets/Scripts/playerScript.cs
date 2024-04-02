using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;

    public LayerMask groundPlayer;
    public bool onTheGround;
    public int jumpHeight;

    public Animator hurting;
    public bool hurtAnim;
    public Animator running;
    public bool right;

    public int healthCount;
    public GameObject gameOverScene;
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public bool gameIsOver;

    public GameObject gameWinScene;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.down;
        Vector2 position = transform.position;
        float distance = 1.0f;
        

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundPlayer);

        if (hit.collider != null)
        {
            onTheGround = true;
        }
        else
        {
            onTheGround = false;
        }
        
        if(Input.GetKey(KeyCode.D) && hurtAnim == false && gameIsOver == false)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            running.Play("running");
            right = true;
        }
        if (Input.GetKey(KeyCode.A) && hurtAnim == false && gameIsOver == false)
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            running.Play("running");
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onTheGround == true && gameIsOver == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        if(healthCount == 3)
        {
            h1.SetActive(true);
            h2.SetActive(true);
            h3.SetActive(true);
        }
        if (healthCount == 2)
        {
            h1.SetActive(true);
            h2.SetActive(true);
            h3.SetActive(false);
        }
        if (healthCount == 1)
        {
            h1.SetActive(true);
            h2.SetActive(false);
            h3.SetActive(false);
        }
        if (healthCount <= 0)
        {
            h1.SetActive(false);
            h2.SetActive(false);
            h3.SetActive(false);
            gameIsOver = true;
            gameOverScene.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            healthCount--;

            hurting.Play("hurt");

            if(right == true)
            {
                transform.position += Vector3.right * -100 * Time.deltaTime;
                transform.position += Vector3.up * 100 * Time.deltaTime;
            }
            if (right == false)
            {
                transform.position += Vector3.right * +100 * Time.deltaTime;
                transform.position += Vector3.up * +100 * Time.deltaTime;
            }
            hurting.Play("hurt");
        }

        if (collision.gameObject.tag == "stomp")
        {
            transform.position += Vector3.up * +100 * Time.deltaTime;
        }


        if (collision.gameObject.tag == "winL1")
        {
            gameIsOver = true;
            gameWinScene.SetActive(true);

            if (0 == PlayerPrefs.GetInt("levelsWon"))
            {
                PlayerPrefs.SetInt("LevelsWon", 1);
            }
        }

        if (collision.gameObject.tag == "winL2")
        {
            gameIsOver = true;
            gameWinScene.SetActive(true);

            if (1 == PlayerPrefs.GetInt("levelsWon"))
            {
                PlayerPrefs.SetInt("LevelsWon", 2);
            }
        }

        if (collision.gameObject.tag == "instantGameOver")
        {
            healthCount = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "heart")
        {
            if (healthCount < 3)
            {
                healthCount++;
            }
        }
    }
}