using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiController : MonoBehaviour
{
    public float velocidad = 10f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private string direccion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direccion = "derecha";
    }

    // Update is called once per frame
    void Update()
    {
        if(direccion =="derecha"){
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                 spriteRenderer.flipX = false;
        }
        if(direccion =="izquierda"){
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
                 spriteRenderer.flipX = true;
        }
    
      
    }
    void OnTriggerEnter2D(Collider2D other){
    
        if (other.gameObject.CompareTag("PARED"))
        {
            if(direccion == "derecha"){
                direccion = "izquierda";
            }else{  direccion = "derecha";  }
        }
     
     
    }
}
