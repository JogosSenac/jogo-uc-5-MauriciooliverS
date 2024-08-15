using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Andar
        float moveH = Input.GetAxis("Horizontal");
        transform.position += new vector3(moveH * velocidade * Time.deltaTime, 0, 0);
    }
}
