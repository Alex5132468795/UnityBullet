using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//!!!!!!!!!!!!
public class bullet : MonoBehaviour
{
    //private Rigidbody2D rb;

    private float speed = 30f;
    private int damage = 5;
    private float distance = 50;
    private int lifetime = 10;
    public LayerMask whatIsSolid;
    //  private int lifeMax = 500;

    void Start()
    {
        Invoke("DestroyBullet", lifetime);
        //  rb = GetComponent<Rigidbody2D>();
        //   rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        Debug.DrawRay(transform.position, transform.up, Color.red);
        // Debug.DrawRay(transform.position, transform.up, Color.red);
        if (hitInfo.collider != null)
        {
            Debug.Log("HitEnemy");
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("HitEnemy"); 
                hitInfo.collider.GetComponent<EnemyScript>().ChangeHealthEnemy(-damage);
                // Instantiate(effect, transform.position, Quaternion.identity);
                Debug.Log("HitEnemy");
                DestroyBullet();
            }
            if (hitInfo.collider.CompareTag("ground"))
            {
                // Instantiate(effect, transform.position, Quaternion.identity);
                DestroyBullet();
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
