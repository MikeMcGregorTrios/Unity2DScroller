using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource audio;

    public float jumpForce;

    private bool jumping = false;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

	}
	
    void Jump()
    {
        jumping = true;
        anim.SetBool("Jumping", true);
        rb.AddForce(new Vector2(0f, jumpForce));

    }

    void Slide()
    {
        anim.SetBool("Slide", true);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(jumping == false)
            {
                Jump();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Slide();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Slide", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cactus"))
        {
            anim.SetBool("Dead", true);
            GameManager.instance.StopAllMoving();
            GameManager.instance.isAlive = false;

        }

        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jumping", false);
            jumping = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.AddScore(10);
            GameManager.instance.coins.Remove(other.gameObject.GetComponent<Coin>());
            Destroy(other.gameObject);
            audio.Play();

        }
    }
}
