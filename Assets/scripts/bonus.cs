using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    public GameObject EffectBonusCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {       
            Destroy(gameObject);
            Instantiate(EffectBonusCoin, transform.position, Quaternion.identity);

        }
    }
}

