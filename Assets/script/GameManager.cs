using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int vidas =3;
    public static int puntos = 1;
    public static bool estoyMuerto = false;

    void Start()
    {
        
    }
    

    void Update()
    {
        Debug.Log ("Puntos" +puntos);
    }
}
