using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float maxTimer = 3.0f;
    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    Animator animator;
    float timer;
    float timerVertical;
    float timeVerticalMax;
    int direction = 1;


    AudioSource audioSource;
    public AudioClip fixClip;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timerVertical = Random.Range(1.0f, 7.0f);
        timeVerticalMax = timerVertical;
        timer = maxTimer;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerVertical -= Time.deltaTime;

        if (timerVertical <= 0)
        {
            if (vertical)
            { 
                vertical = false;
            }
            else
            { 
                vertical = true;
            }
        timerVertical = timeVerticalMax;
        }

        if (timer <= 0)
        {
            direction = -direction;
            timer = maxTimer;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * direction * speed;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * direction * speed;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }


        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        audioSource.PlayOneShot(fixClip, 0.2f);

    }

}
