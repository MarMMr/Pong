using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscenaFinal : MonoBehaviour
{
    public TextMeshProUGUI JugadorGanador;


    // Start is called before the first frame update
    void Start()
    {
        JugadorGanador.text = "¡El ganador es: " + GameManager.ganador + "!";
    }


    public void Jugar()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        Destroy(gameManager);

        SceneManager.LoadScene("Juego");
    }
    public void Salir()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
