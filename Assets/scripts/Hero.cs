using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Hero : MonoBehaviour
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
    public GameObject panelHealth;
    public EnemyScript enemy;


   
    private bool _isGrounded;
    public static Rigidbody2D _rb;
    private int _score = 10;
    private int _minHealth=10;
    private int _maxHealth = 20;
    private  int _health;
    private float moveInput;
    private  Animator anim;
    private bool facingRight = true;

    public GameObject bow;
    private void Awake()
    {
        _health = _maxHealth;
    }
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

        if(_health <= _minHealth)
        {
            panelHealth.SetActive(true);
        }

        else if(_health >= _minHealth)
        {
            panelHealth.SetActive(false);
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(moveInput * Speed, _rb.velocity.y);
        if (facingRight == false && _rb.velocity.x < 0)
        {
            bow.GetComponent<Bow>().offset = -90;
            Flip();
        }
        else if (facingRight == true && _rb.velocity.x > 0)
        {
            bow.GetComponent<Bow>().offset = 270;
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("Run", false);

        }
        else
        {
            anim.SetBool("Run", true);
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
        healthDisplay.text = "" + _health;
        if (_health > 20)
        {       
            _health = _maxHealth;
        }
        _isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * JumpForce;
        }
        if (_isGrounded == true)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
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
    
    public void PlusScore(int scoreValue)
    {
        _score += scoreValue;
        scoreDisplay.text = "" + _score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bonus"))
        {
            PlusScore(+1);
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

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {           
    //            anim.SetTrigger("AttackHero");                          
    //    }
    //}

    public void ChangeHealthEnemyAnim()
    {
        enemy.ChangeHealthEnemy(-2);       
    }

}
