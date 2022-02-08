using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Money : MonoBehaviour
{
    public int moneyValue;

    private MoneyManager _moneyManager;
    // Start is called before the first frame update
    void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _moneyManager.AddMoney(moneyValue);
            Destroy(gameObject);
        }
    }
}
