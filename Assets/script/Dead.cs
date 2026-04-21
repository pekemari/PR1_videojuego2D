using UnityEngine;

public class Dead : MonoBehaviour
{

    private GameObject personaje;
    private movPersonaje _movPersonaje;

    void Start()
    {
        personaje = GameObject.Find("Personaje");
        _movPersonaje = personaje.GetComponent<movPersonaje>();
      
    }
    
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log(col.name);

        if(col.name == "Personaje")
        {
            _movPersonaje.Respawnear();
        }

    }




}
