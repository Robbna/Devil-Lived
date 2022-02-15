using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimation;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float attackDelay;
    [SerializeField] private Transform attackObj;
    [SerializeField] private float radiusAttack;
    [SerializeField] private int attackDamage;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float forceScaleAttack;
    private float timer;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (GetComponent<Enemy>().isAlive)
        {
            if (Player.isAlive)
            {
                timer += Time.deltaTime;
                if (timer >= timeBetweenAttacks)
                {

                    if (transform.position.x > playerTransform.position.x)
                    {
                        attackObj.localPosition = new Vector2(-1.03f, 0);

                        StartCoroutine(Attack(attackDelay));

                    }
                    if (transform.position.x < playerTransform.position.x)
                    {
                        attackObj.localPosition = new Vector2(1.03f, 0);

                        StartCoroutine(Attack(attackDelay));


                    }
                    timer = 0;
                }
            }

        }


    }

    //***Método de ataque principal
    IEnumerator Attack(float delay)
    {
        //Lista de colisiones con las que _colisionará_ el objeto "attackObj"
        Collider2D[] listColliders = Physics2D.OverlapCircleAll(attackObj.position, radiusAttack);

        //Recorremos la lista
        foreach (Collider2D collider in listColliders)
        {
            //Si el objeto colisionado tiene el tag "Enemy"
            if (collider.CompareTag("Player"))
            {
                enemyAnimation.SetTrigger("Attack");
                yield return new WaitForSeconds(delay);
                if (PlayerMovement.isLeft)
                {
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceScaleAttack, ForceMode2D.Impulse);
                }
                if (PlayerMovement.isRight)
                {
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceScaleAttack, ForceMode2D.Impulse);
                }
                collider.gameObject.GetComponent<Player>().Hitted(attackDamage);

            }
        }
    }
    //*** Método !PROVISIONAL para ver el rando de ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackObj.transform.position, radiusAttack);
    }
}
