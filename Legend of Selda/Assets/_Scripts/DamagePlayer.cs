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
    public GameObject canvasDamage;

    private CharacterStats _statsPlayer;
    private CharacterStats _stats;

    private void Start()
    {
        _statsPlayer = GameObject.Find("Player").GetComponent<CharacterStats>();
        _stats = GetComponent<CharacterStats>();
    }

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
            float strFac = 1 + _stats.strengthLevels[_stats.level] / CharacterStats.MAX_STAT_VALUE;
            float plFac = 1 - _statsPlayer.defenseLevels[_statsPlayer.level] / CharacterStats.MAX_STAT_VALUE;
            int totalDamage = Mathf.Clamp((int)(damage * strFac * plFac),
                                        1, CharacterStats.MAX_HEALTH);

            if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < _statsPlayer.luckLevels[_statsPlayer.level])
            {
                if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) > _stats.accuracyLevels[_stats.level])
                {
                    totalDamage = 0;
                }
            }
            
            GameObject clone = Instantiate(canvasDamage,
                other.gameObject.transform.position,
                Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);
        }
    }
}
