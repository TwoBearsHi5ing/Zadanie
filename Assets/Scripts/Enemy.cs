using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float EnemySpeed;
    [SerializeField] private float VisionRange;
    [SerializeField] private Transform PlayerPosition;

    private Rigidbody2D _rigidbody;
    private bool isDead = false;

    private void RunAway()
    {
        Vector3 normDir = (PlayerPosition.position - transform.position).normalized;

        _rigidbody.velocity = new Vector2(-normDir.x * EnemySpeed, -normDir.y * EnemySpeed);
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isDead)
        {
            RunAway();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody.isKinematic = true;
            isDead = true;
            _rigidbody.velocity = Vector3.zero; 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
