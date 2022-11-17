using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{

    private int _health=10;
    public Text healthDisplay;
    private int _score = 0;
    public Text scoreDisplay;
    public GameObject panel;
    private Rigidbody2D _rb;
    private float _speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        healthDisplay.text = "" + _health;
        scoreDisplay.text = "" + _score;
    }
    private void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rb.velocity.y);


        if (_health>=0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
    public void ChangeHealth(int healthValue)
    {
        _health += healthValue;
        healthDisplay.text = "" + _health;

    }
    public void Kill()
    {
        _score++;
        scoreDisplay.text = "" + _score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("bonus"))
        {
            Kill();
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

}
