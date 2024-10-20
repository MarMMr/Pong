using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    float y;
    public float speed = 10;
    public string axis = "Vertical";
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxisRaw(axis); 
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, y) * speed;

    }
}
