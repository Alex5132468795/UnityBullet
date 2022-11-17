using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealthScript : MonoBehaviour
{
    public Hero player;
    public GameObject EffectHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.ChangeHealth(+5);
            Instantiate(EffectHealth, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
