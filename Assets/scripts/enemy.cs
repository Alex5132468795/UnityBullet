using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {                       
            Destroy(gameObject);
        }
        if (collision.CompareTag("bonus"))
        {
            Destroy(gameObject);
        }
    }
}
