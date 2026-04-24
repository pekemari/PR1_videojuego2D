using UnityEngine;
using UnityEngine.InputSystem;

public class movPersonaje : MonoBehaviour
{

    public float velocidad = 0.03f;
    public float impulsoSalto = 7.0f;
     
    public Vector3 inicioPersonaje = new Vector3 (1,2,3);

    Rigidbody2D rb;

    Animator controlAnimacion;

    bool puedoSaltar = false;

    GameObject Respawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position =  inicioPersonaje;

        rb = GetComponent<Rigidbody2D>();

        Respawn = GameObject.Find("Respawn");

        Respawnear(); 

        controlAnimacion = GetComponent <Animator> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        controlAnimacion. SetBool ("activaCamina", true);

        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x * velocidad,moveInput.y * velocidad, 0);

        //flip//
        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        else if(moveInput.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        //Animacion 
        if (moveInput.x !=0)
        {
            controlAnimacion. SetBool ("activaCamina", true);
        }
        else
        {
            controlAnimacion. SetBool ("activaCamina", false);
        }


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down* 0.5f, Color.red);

        if(hit.collider == true)
        {
            
            puedoSaltar = true; 
        }
        else
        {
            puedoSaltar = false;
        }

        //Salto//

        bool salto =InputSystem.actions["Jump"].WasPressedThisFrame();
        if(salto == true && puedoSaltar == true)
        {
            Debug.Log("salto");
            rb.AddForce(transform.up* impulsoSalto ,ForceMode2D.Impulse);

            this.GetComponent <SpriteRenderer>().color = Color.red;
        } 
        else
        {
            this.GetComponent <SpriteRenderer>().color = Color.white;
        }


        //Comprobar si me salgo de la pantalla//
        if(transform.position.y <= -7)
        {
            Respawnear();
        }   

    }

     public void Respawnear()
    {
        transform.position = Respawn.transform.position;
        Debug.Log ("vidas" +GameManager.vidas);
        GameManager.vidas = GameManager.vidas -1;
        Debug.Log ("vidas" +GameManager.vidas);

    }

    //0 vidas
   
}

