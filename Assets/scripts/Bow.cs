using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//!!!!!!!!!!!!!!!!!!!
public class Bow : MonoBehaviour
{
    public float offset;
    public GameObject arrow;
    public Transform shotPoint;
    private float startKd = 0.5f;
    private float Kd;
    void Start()
    {


    }
    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        // shotPoint.rotation = Quaternion.Euler(0f, 0f, rotZ - offset);

        if (Kd <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                // Instantiate(bullet, shotPoint.position, shotPoint.rotation);

                Instantiate(arrow, shotPoint.position, transform.rotation);
                Kd = startKd;
            }
        }
        else
        {
            Kd -= Time.deltaTime;
        }

    }
}