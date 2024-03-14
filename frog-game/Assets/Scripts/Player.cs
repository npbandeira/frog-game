using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpingForce;
    public bool isJumping;
    public bool dobleJumping;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();//Acessar o Componente
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);//Pega o inputes Prontos da Inuty para movimentar o personagem
        transform.position += movement * Time.deltaTime * Speed;
        PlayerAnimation();
    }

    void Jump()
    {
        //Logica para pula simples na unity
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpingForce), ForceMode2D.Impulse);
                dobleJumping = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (dobleJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpingForce), ForceMode2D.Impulse);
                    dobleJumping = false;
                }
            }
        }
    }

    void PlayerAnimation()
    {
        if (Input.GetAxis("Horizontal") > 0f) // direita
        {//aplica a movimentação
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f) //esquerda
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f) // idle
        {
            anim.SetBool("run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}
