using UnityEngine;

public class Dead : MonoBehaviour
{

    private GameObject personaje;
    private MovPersonaje movPersonaje;

    void Start()
    {
        personaje = GameObject.Find("Personaje");
        movPersonaje = personaje.GetComponent<MovPersonaje>();
      
    }
    
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log(col.name);

        if(col.name == "Personaje")
        {
            movPersonaje.Respawnear();
        }

    }




}
