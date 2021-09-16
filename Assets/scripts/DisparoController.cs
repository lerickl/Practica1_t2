  
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisparoController : MonoBehaviour
{
    // Start is called before the first frame update
public float velocityX = 15f;

    private const string ENEMY_TAG = "Enemy"; 

    private Rigidbody2D rb;
    private gameController _game;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _game = FindObjectOfType<gameController>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    

        if (collision.gameObject.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            _game.addpuntos(10);
            Debug.Log(_game.GetScore());
            // que le pasara al enemigo
        }
    }
}
