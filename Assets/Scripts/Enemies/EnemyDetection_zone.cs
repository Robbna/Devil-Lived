using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection_zone : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private float speed;

    private Vector2 playerDirection;
    public static bool isNear;
    public static bool isPlayerOnTheLeft, isPlayerOnTheRight;

    private void Start()
    {
        speed *= Time.deltaTime;
        isNear = false;
    }

    private void Update()
    {
        if (enemyPosition.position.x >= playerPosition.position.x)
        {
            isPlayerOnTheLeft = true;
        }
        else
        {
            isPlayerOnTheRight = true;
        }



        playerDirection = playerPosition.position - enemyPosition.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            enemyPosition.Translate(playerDirection * speed);
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
