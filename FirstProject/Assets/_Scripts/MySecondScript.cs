using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondScript : MonoBehaviour
{
    //Constantes
    public const float PI = 3.14159265f;
    
    //Solo lectura
    public readonly int numberOfEnemies;

    public MySecondScript()
    {
        numberOfEnemies = 5;
    }

    private void Start()
    {
        Inventory<Weapon> weapons = new Inventory<Weapon>();
    }

    public bool AttackEnemy(int damage)
    {
        return true;
    }

    public bool AttackEnemy(string player)
    {
        return true;
    }

    public bool AttackEnemy(float damage)
    {
        return true;
    }

    public float AttackEnemy(float damage, bool player)
    {
        return 1f;
    }
}
