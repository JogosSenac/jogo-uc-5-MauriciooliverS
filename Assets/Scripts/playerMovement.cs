using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool comVida = true;
    public float moveH;
    public int velocidade;
    public int forcaPulo;
    private Rigidbody2D rb;
    private Animator animPlayer;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Andar
        float moveH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, 0);
        if(Input.GetKey(KeyCode.W))
        {
            animPlayer.SetLayerWeight(2,1);
        }
        else
        {
            animPlayer.SetLayerWeight(2,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            animPlayer.SetLayerWeight(1,1);
        }
        else
        {
            animPlayer.SetLayerWeight(1,0);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
        }
        } 
    private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Chão"))
            {
                isJumping = false;
            }         
            if(other.gameObject.CompareTag("Morte"))
            {
                comVida = false;
                Destroy(other.gameObject);
            }
        }
    }
