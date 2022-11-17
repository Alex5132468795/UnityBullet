using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
 
    [Header("Control")]
    public float Speed;
    public float JumpForce = 300f;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Header("Text")]
    public Text scoreDisplay;
    public Text healthDisplay;


    [Header("WhatIsGO")]
    public Transform feetPos;
    public GameObject aura;
    public GameObject panel;
    public GameObject panelPause;



    private bool _isGrounded;
    private Rigidbody2D _rb;
    private int _score = 10;
    private int _health = 20;
    private float moveInput;
    private Animator anim;
    private bool facingRight = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = "" + _health;
        scoreDisplay.text = "" + _score;
    }

    void FixedUpdate()
    {
        if (_health <= 0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(moveInput * Speed, _rb.velocity.y);
        if (facingRight == false && _rb.velocity.x < 0)
        {
            Flip();
        }
        else if (facingRight == true && _rb.velocity.x > 0)
        {
            Flip();
        }

        if (moveInput==0)
        {
            anim.SetBool("isRunning", false);

        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up*JumpForce;
        }
        if (_isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 20f;
            aura.SetActive(true);

        }
        else
        {
            Speed = 15f;
            aura.SetActive(false);
        }


    }
    public void ChangeHealth(int healthValue)
    {
        _health += healthValue;
        healthDisplay.text = "" + _health;

    }
    public void TakeBonus()
    {
        _score++;
        scoreDisplay.text = "" + _score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("bonus"))
        {
            TakeBonus();
        }
        if (collision.CompareTag("enemy"))
        {
            ChangeHealth(-2);

        }
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        panelPause.SetActive(true);
      
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
      
    }

}
