using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Jug1Punt;
    public TextMeshProUGUI Jug2Punt;
    public GameObject pelota;
    public GameObject spawnPelota;
    public int puntosVictoria = 3;
    int puntosJ1 = 0;
    int puntosJ2 = 0;
    public static string ganador = "";

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void ReiniciarPelota()
    {
        Instantiate(pelota,
            spawnPelota.gameObject.transform.position,
            Quaternion.identity);
    }

    public void PuntoJ1()
    {
        puntosJ1++;
        Jug1Punt.text = puntosJ1.ToString();
        if (puntosJ1 == puntosVictoria)
        {
            ganador = "Jugador1";
            SceneManager.LoadScene("EscenaFinal");
        }
        ReiniciarPelota();

    }

    public void PuntoJ2()
    {
        puntosJ2++;
        Jug2Punt.text = puntosJ2.ToString();
        if (puntosJ2 == puntosVictoria)
        {
            ganador = "Jugador2";
            SceneManager.LoadScene("EscenaFinal");
        }
        ReiniciarPelota();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
