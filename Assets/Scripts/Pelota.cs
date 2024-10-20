using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{   
    GameManager gameManager;
    public int speed = 20;
    public AudioClip choqueBola;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gMObject =
            GameObject.Find("GameManager");

        gameManager =
            gMObject.GetComponent<GameManager>();


        // impulso inicial
       if ( Random.Range(0, 10) >= 5)
        {
            GetComponent<Rigidbody2D>().velocity =
            Vector2.right * speed;
        }
       else
        {
            GetComponent<Rigidbody2D>().velocity =
            Vector2.left * speed;
        }

    }

    
    float reboteY(Vector2 bolaPos, Vector2 raquetaPos,
                    float alturaRaqueta)
    {
        // || 1 <- parte superior de la raqueta
        // ||
        // || 0 <- parte media de la raqueta
        // ||
        // || -1 <- parte inferior de la raqueta
        return (bolaPos.y - raquetaPos.y) / alturaRaqueta;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(choqueBola, transform.position, 1);
        //col es el objecto que recibe la colisión de la pelota
        if (col.gameObject.name == "RaquetaIzq")
        {
            // Calculamos la dirección de rebote
            float y = reboteY(
            transform.position,//posicion de la pelota
            col.transform.position, //posicion de la raqueta
            col.collider.bounds.size.y);//tamaño de la raqueta
                                        // Calculamos la dirección, lo normalizamos para que el tamaño
                                        //del vector sea 1al chocar con la raqueta izda
                                        //la dirección x será 1 (hacia la derecha)
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        // golpea la raqueta derecha
        if (col.gameObject.name == "RaquetaDer")
        {
            // Calculate hit Factor
            float y = reboteY(transform.position,
            col.transform.position,
           col.collider.bounds.size.y);
            // en este caso se mueve hacia la izda (x=-1)
            Vector2 dir = new Vector2(-1, y).normalized;
            // se aplica la velocidad
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        // golpea el borde derecho
        if (col.gameObject.name == "BordeDer")
        {
            gameManager.PuntoJ1();
            Destroy(this.gameObject);
        }
        // golpea el borde izquierdo
        if (col.gameObject.name == "BordeIzq")
        {
            gameManager.PuntoJ2();
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
