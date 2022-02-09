using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //_______ Variables expuestas en el editor _______
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    //_______ Variables para instanciar _______
    private bool isHolding;
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
        //_______ Si el jugador se mueve a la derecha _______
        if (dirX > 0f)
        {
            spr.flipX = false;
            RunAnimation(true);
        }
        //_______ Si el jugador se mueve a la izquierda _______
        else if (dirX < 0f)
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
        if (mCheckGround.isGrounded == false)
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

        //********//********//******** MOVIMIENTO DEL JUGADOR
        if (mButtonManager.isHolding && mButtonManager.direction.Equals("left"))
        {
            dirX = -1.0f;
            transform.Translate(Vector2.right * dirX * speed);
        }
        else if (mButtonManager.isHolding && mButtonManager.direction.Equals("right"))
        {
            dirX = 1.0f;
            transform.Translate(Vector2.right * dirX * speed);
        }
        else
        {
            dirX = 0.0f;
        }

        print(dirX);
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

    public void ButtonPressed(bool isPressed)
    {
        //_______ Si el jugador está presionando el botón, "isHolding" es true _______
        if (isPressed)
        {
            mButtonManager.isHolding = true;
        }
        //_______ Cuando lo suelta es false _______
        else
        {
            mButtonManager.isHolding = false;
        }
    }
    public void ButtonDirection(string direction)
    {
        //_______ Si el jugador está presionando el botón izquierdo, "direction" es "left" _______
        if (direction.Equals("left"))
        {
            mButtonManager.direction = "left";
        }
        //_______ Si el jugador está presionando el botón derecho, "direction" es "right" _______
        if (direction.Equals("right"))
        {
            mButtonManager.direction = "right";
        }
    }

    public void Jump()
    {
        if (mCheckGround.isGrounded)
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