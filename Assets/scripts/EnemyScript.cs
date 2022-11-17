using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Hero player;
    private Rigidbody2D rb;
    public float speed;
    public GameObject Hero;
    private int _health=15;
    public GameObject EffectDeath;

    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_health <= 0)
        {
            player.PlusScore(+5);
            Destroy(gameObject);
            Instantiate(EffectDeath,transform.position,Quaternion.identity);
           
        }
        if (Hero.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(rb.position, Hero.transform.position, speed * Time.deltaTime);
    }
    public void ChangeHealthEnemy(int healthValue)
    {
        _health += healthValue;     
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bullet"))
        {
            ChangeHealthEnemy(20);
        }
    }
}


