using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection_zone : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float speed;

    private Vector2 playerDirection;
    private bool isNear;

    private void Start()
    {
        speed *= Time.deltaTime;
        isNear = false;
    }

    private void Update()
    {
        if (GetComponentInParent<Enemy>().isAlive)
        {
            if (Player.isAlive)
            {
                if (isNear)
                {
                    playerDirection = playerPosition.position - enemy.transform.position;
                    enemy.transform.Translate(playerDirection * speed);
                    GetComponentInParent<Animator>().SetBool("isRunning", true);

                }
                else
                {
                    GetComponentInParent<Animator>().SetBool("isRunning", false);

                }
            }
            else
            {
                GetComponentInParent<Animator>().SetBool("isRunning", false);
                speed = 0f;
            }
        }
        else
        {
            //speed = 0f;
        }



    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isNear = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
