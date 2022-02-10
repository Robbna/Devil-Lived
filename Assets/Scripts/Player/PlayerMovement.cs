using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    //Variables para instanciar
    private Rigidbody2D rg;
    private SpriteRenderer spr;
    private Animator playerAnimator;
    [SerializeField] private Transform attackObj;
    //Variables necesarias para PlayerMovement
    private bool isHolding;
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

        //Si el jugador se mueve a la derecha
        if (dirX > 0f)
        {
            spr.flipX = false;
            RunAnimation(true);
        }
        //Si el jugador se mueve a la izquierda
        else if (dirX < 0f)
        {
            spr.flipX = true;
            RunAnimation(true);
        }
        //Si el jugador está quieto
        else
        {
            RunAnimation(false);
        }

        //***CONDICIONES

        //Si el jugador está tocando el suelo
        if (mCheckGround.isGrounded == false)
        {
            RunAnimation(false);
            JumpAnimation(true);
        }
        else
        {
            JumpAnimation(false);
        }

        Movement();





    }
    // ---------------------------------------------------------------
    //      Fixed Update, funcionamiento correcto de las físicas
    // ---------------------------------------------------------------
    private void FixedUpdate()
    {
        //***INPUT
        if (Input.GetKeyDown(KeyCode.F))
        {
            Jump();
        }

    }
    // -----------------
    //      Métodos
    // -----------------
    public void Movement()
    {
        //***MOVIMIENTO DEL JUGADOR
        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * speed);
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
    }

    public void ButtonPressed(bool isPressed)
    {
        //Si el jugador está presionando el botón, "isHolding" es true
        if (isPressed)
        {
            mButtonManager.isHolding = true;
        }
        //Cuando lo suelta es false
        else
        {
            mButtonManager.isHolding = false;
        }
    }
    public void ButtonDirection(string direction)
    {
        //Si el jugador está presionando el botón izquierdo, "direction" es "left"
        if (direction.Equals("left"))
        {
            mButtonManager.direction = "left";
        }
        //Si el jugador está presionando el botón derecho, "direction" es "right"
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
        if (spr.flipX == false)
        {
            attackObj.localPosition = new Vector2(1.03f, 0);
        }
        if (spr.flipX)
        {
            attackObj.localPosition = new Vector2(-1.03f, 0);
        }
        AttackAnimation();
    }
    //***METODO PARA LAS ANIMACIONES
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