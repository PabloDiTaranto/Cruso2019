using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hara el arma")]
    public int damage;

    public GameObject bloodAnim;
    private GameObject _hitPoint;
    public GameObject canvasDamage;

    private void Start()
    {
        _hitPoint = transform.Find("HitPoint").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (bloodAnim != null && _hitPoint != null)
            {
                Destroy(Instantiate(bloodAnim,
                    _hitPoint.transform.position,
                    _hitPoint.transform.rotation),0.5f);
            }

            GameObject clone = Instantiate(canvasDamage,
                                      _hitPoint.transform.position,
                                Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = damage;
            
            col.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
