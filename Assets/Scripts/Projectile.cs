using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public AudioClip FixClip;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController bot = other.collider.GetComponent<EnemyController>();
        if (bot != null)
        {
            bot.Fix();
        }
        Destroy(gameObject);
    }
}
