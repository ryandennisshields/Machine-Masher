using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour
{
    private BaseEnemy baseEnemy; // Stores the Base Enemy script
    private EnemyHealth enemyHealth; // Stores the Enemy Health script

    // Start is called before the first frame update
    void Start()
    {
        baseEnemy = GetComponent<BaseEnemy>(); // Sets "base enemy" to the Base Enemy script
        enemyHealth = GetComponent<EnemyHealth>(); // Sets "enemy health" to the Enemy Health script
        // Variables used for this "Robo" enemy
        enemyHealth.health = 100;
        baseEnemy.gravity = -15;
        baseEnemy.speed = 4;
        baseEnemy.distance = 5;
        baseEnemy.bulletDamage = 25;
        baseEnemy.bulletSpeed = 5000;
        baseEnemy.bulletDelay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Functions used for this "Robo" enemy
        baseEnemy.MoveTowards();
        baseEnemy.LookTowards();
        baseEnemy.Shooting();
    }
}
