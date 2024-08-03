using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playeController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed, jumpForce;

    public float projectileForce = 0;

    public int score;

    public TMP_Text scoreText;

    public AudioSource audioPlayer;

    public CoinManager cm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }



        if (Input.GetKey(KeyCode.Space))
        {
            projectileForce += 2 * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 1;
            rb.AddForce(transform.right * projectileForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (transform.position.y <= -5)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionTag")
        {
            audioPlayer.Play();
        }

    }   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}