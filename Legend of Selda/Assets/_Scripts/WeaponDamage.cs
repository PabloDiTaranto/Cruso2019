using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hara el arma")]
    public int damage;

    public string weaponName;
    public GameObject bloodAnim;
    private GameObject _hitPoint;
    public GameObject canvasDamage;

    private CharacterStats _stats;

    private void Start()
    {
        _hitPoint = transform.Find("HitPoint").gameObject;
        _stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            CharacterStats enemyStats = col.gameObject.GetComponent<CharacterStats>();

            float plFac = (1 - _stats.strengthLevels[_stats.level] / CharacterStats.MAX_STAT_VALUE);
            float eneFac = (1 - enemyStats.defenseLevels[enemyStats.level] / CharacterStats.MAX_STAT_VALUE);
            
            int totalDamage = (int)(damage * plFac * eneFac) ;

            if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < _stats.accuracyLevels[_stats.level])
            {
                if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < enemyStats.luckLevels[enemyStats.level])
                {
                    totalDamage = 0;
                }
                else
                {
                    totalDamage *=5;
                }
            }
            if (bloodAnim != null && _hitPoint != null)
            {
                Destroy(Instantiate(bloodAnim,
                    _hitPoint.transform.position,
                    _hitPoint.transform.rotation),0.5f);
            }

            GameObject clone = Instantiate(canvasDamage,
                                      _hitPoint.transform.position,
                                Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            
            col.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);
        }
    }
}
