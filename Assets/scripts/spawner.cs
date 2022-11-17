using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawnItemEnemy;
    public GameObject spawnItemBonus;
    private float _randPositionX;
    private Vector2 _positionSpawn;
    public float _spawnTime=1f;
    private float _nextSpawn = 0f;
    private int randomItem;
 
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnTime;
            _randPositionX = Random.Range(-10f, 52.62f);
            _positionSpawn = new Vector2(_randPositionX, transform.position.y);
            randomItem = Random.Range(1, 10);
            /*if (randomItem > 10)
            {
                Instantiate(spawnItemBonus, _positionSpawn, Quaternion.identity);
            }*/
            if (randomItem < 10)
            {
                Instantiate(spawnItemEnemy, _positionSpawn, Quaternion.identity);
            }
           
        }
    }
  
}
