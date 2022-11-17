using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public Hero player;
    public EnemyScript enemy;
    public Animator anim;
    public float startTimeBtwAtack;
    public float timeBtwAtack;
    private void OnTriggerStay2D(Collider2D other)
    {                 
       if (other.CompareTag("Player")&& timeBtwAtack <= 1)
        {           
                anim.SetTrigger("AttackEnemy");                         
        }
        else
        {
            if(timeBtwAtack<0)
            {
                timeBtwAtack = 0;
            }
            else
            {
                timeBtwAtack -= Time.deltaTime;
            }          
        }
  
    }

    public void OnEnemyAttack()
    {      
        player.ChangeHealth(-2);      
        timeBtwAtack = startTimeBtwAtack;
    }

}
