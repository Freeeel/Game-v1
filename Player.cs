using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public static Player Instance { get; private set; }


    /*ХП*/
    public float health;
    public int numHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite deadHeart;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }


    private void FixedUpdate()
    {
        if (health > numHearts)
        {
            health = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = deadHeart;
            }
        }
        if (health == 0)
        {
            Debug.Log("dead");
            health = 3;
        }
    }


    private void Run()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + move, speed * Time.deltaTime);
        sprite.flipX = move.x > 0.0f;
    }


    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
    }


    public void GetDamage()
    {
        health -= 1;
        Debug.Log(health);
    }

}
