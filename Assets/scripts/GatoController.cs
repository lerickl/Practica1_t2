using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoController : MonoBehaviour
{
    public gameController _game;
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR=2;    
    private const int ANIMATION_DESLIZA = 3;   
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool EstaSaltando = false;
     private bool EstaDeslizando = false;
     private bool EstaEnSuelo = false;
    
    private float fuerzaSalto=30f;
    public float velocidad = 15f;
    
    public GameObject rightBullet;
    public GameObject leftBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _game = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EstaSaltando==false&&EstaDeslizando==false){ CambiarAnimacion(ANIMATION_QUIETO); }
       
        rb.velocity = new Vector2(0, rb.velocity.y); 
        if (Input.GetKey(KeyCode.D)) 
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                
                spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha
         
                if(EstaSaltando==false&& EstaDeslizando==false)
                { 
                    CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                } 
            } 
        if (Input.GetKey(KeyCode.A)) 
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
            
            spriteRenderer.flipX = true;//Que mi objeto mire hacia la derecha
     
            if(EstaSaltando==false && EstaDeslizando==false)
            { 
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
            } 
        } 
        if (Input.GetKey(KeyCode.W) &&  EstaSaltando == false)
                {
                    CambiarAnimacion(ANIMATION_SALTAR);
                    EstaSaltando = true;
                    Saltar(); 
                 }
        if (Input.GetKeyUp(KeyCode.C))
        {
           
            var bullet = spriteRenderer.flipX ? leftBullet : rightBullet;
            if(spriteRenderer.flipX){
                var position = new Vector2(transform.position.x-15f, transform.position.y);
                var rotation = rightBullet.transform.rotation;
                  Instantiate(bullet, position, rotation);
            }else{
                var position = new Vector2(transform.position.x+15f, transform.position.y);
                var rotation = rightBullet.transform.rotation;
                  Instantiate(bullet, position, rotation);
            }
            
         
        }
        if(Input.GetKeyDown(KeyCode.F)){
            EstaDeslizando = true;
            CambiarAnimacion(ANIMATION_DESLIZA);
        }  
        
        if(Input.GetKeyUp(KeyCode.F)){
            EstaDeslizando = false;
       
        } 
   
     
  
    
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="bronze"){
         
            _game.addMonedas("bronze");
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag=="plata"){
            _game.addMonedas("plata");
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag=="oro"){
            _game.addMonedas("oro");
            Destroy(other.gameObject);
        }
    } void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Enemy"){
         
            Destroy(this.gameObject);
        } 
        EstaSaltando = false;
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
    private void Saltar()
    {
 
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }
  
}