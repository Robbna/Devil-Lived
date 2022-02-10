using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimation;
    //Variables expuestas en el editor
    private SpriteRenderer spr;
    [SerializeField] private Transform attackObj;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float attackDamage;
    private float timer;
    [SerializeField] private float timeBetweenAttacks;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (Player.isAlive)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenAttacks)
            {

                if (EnemyDetection_zone.isPlayerOnTheLeft)
                {
                    attackObj.localPosition = new Vector2(-1.03f, 0);
                    if (EnemyAttack_zone.isNearToAttack)
                    {
                        Attack();
                    }
                }
                if (EnemyDetection_zone.isPlayerOnTheRight)
                {
                    attackObj.localPosition = new Vector2(1.03f, 0);
                    if (EnemyAttack_zone.isNearToAttack)
                    {
                        Attack();

                    }
                }
                timer = 0;
            }
        }


    }

    //***Método de ataque principal
    private void Attack()
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
