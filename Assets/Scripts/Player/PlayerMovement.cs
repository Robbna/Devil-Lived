using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //_______ Variables expuestas en el editor _______
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    //_______ Variables para instanciar _______
    private Rigidbody2D rg;
    private SpriteRenderer spr;
    private Animator playerAnimator;
    //_______ Variables normales _______
    private float dirX, dirY;
    // ---------------
    //      Start
    // ---------------
    private void Start()
    {
        speed *= Time.deltaTime;
        rg = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }
    // ----------------
    //      Update
    // ----------------
    private void Update()
    {
        //********//********//******** MOVIMIENTO DEL JUGADOR
        dirX = Input.GetAxisRaw("Horizontal") * speed;
        transform.Translate(Vector2.right * dirX * speed);

        //_______ Si el jugador se mueve a la derecha _______
        if (dirX > 0)
        {
            spr.flipX = false;
            RunAnimation(true);
        }
        //_______ Si el jugador se mueve a la izquierda _______
        else if (dirX < 0)
        {
            spr.flipX = true;
            RunAnimation(true);
        }
        //_______ Si el jugador está quieto _______
        else
        {
            RunAnimation(false);
        }

        //********//********//******** CONDICIONALES
        //_______ Si el jugador está tocando el suelo _______
        if (CheckGround.isGrounded == false)
        {
            RunAnimation(false);
            JumpAnimation(true);
        }
        else
        {
            JumpAnimation(false);
        }

        //********//********//******** INPUT 
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }

    }
    // ---------------------------------------------------------------
    //      Fixed Update, funcionamiento correcto de las físicas
    // ---------------------------------------------------------------
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }
    // ---------------------
    //      Fixed Update
    // ---------------------
    //********//********//******** MÉTODOS PARA LAS ACCIONES
    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Attack()
    {
        AttackAnimation();
    }
    //********//********//******** MÉTODOS PARA LAS ANIMACIONES
    private void RunAnimation(bool b)
    {
        playerAnimator.SetBool("isRunning", b);
    }

    private void JumpAnimation(bool b)
    {
        playerAnimator.SetBool("isJumping", b);
    }

    private void AttackAnimation()
    {
        playerAnimator.SetTrigger("Attack");
    }

}