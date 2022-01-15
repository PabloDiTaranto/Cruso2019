using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    /*[Tooltip("Tiempo que tarda el player en revivir")]
    public float timeToRevivePlayer;
    private float _timeRevivalCounter;
    private bool _bPlayerReviving;
    private GameObject _player;
    */
    public int damage;
    

    // Update is called once per frame
    /*void Update()
    {
        if (_bPlayerReviving)
        {
            _timeRevivalCounter -= Time.deltaTime;
            if (_timeRevivalCounter < 0)
            {
                _bPlayerReviving = false;
                _player.SetActive(true);
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
