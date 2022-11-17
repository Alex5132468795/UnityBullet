using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    public Hero player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            Debug.Log(Hero._rb.velocity.y);
        }
        if (collision.gameObject.tag.Equals("ground") && Hero._rb.velocity.y < -38)
        {
            player.ChangeHealth(-5);
        }
    }
}
