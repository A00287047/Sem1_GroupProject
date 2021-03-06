using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3f;
    
    public int score = 0;

    public float xPos;

    public GameObject[] gameObjects;
    [HideInInspector]
    public bool is_EnemyBullet = false;

    void Start()
    {
        if (is_EnemyBullet)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate_Timer);

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "EnemyPlane")
        {
            gameObject.SetActive(false);
        }
    }
}
