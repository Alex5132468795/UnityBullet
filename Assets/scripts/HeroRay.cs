using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;


public class HeroRay : MonoBehaviour
{
    private Animator anim;
    private Vector3 difference;
    
    public Transform playerTransform;
    private float distanse = 20;
    public LayerMask layerMask;
    public Collider2D collHero;
    private bool isEnemyEntry;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CheckTag();
          //  anim.SetTrigger("AttackHero");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isEnemyEntry = true;
        }
        else
        {
            isEnemyEntry = false;
        }
    }
    public void CheckTag()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(playerTransform.position, difference, distanse , layerMask);
        Debug.DrawRay(playerTransform.position, difference , Color.red);
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition)- playerTransform.position;
      
        if (hitInfo.collider != null && Input.GetMouseButton(0))
        {
            if (hitInfo.collider.tag == "Enemy"&& isEnemyEntry)
            {
                anim.SetTrigger("AttackHero");
            }
        
            Debug.Log(hitInfo.collider.name);
           
        }
    }


}


