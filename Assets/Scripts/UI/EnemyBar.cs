using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    [SerializeField] private Text enemyText;

    private void Update()
    {
        enemyText.text = Player.enemyDefeat.ToString();
    }
}
