using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public const int MAX_STAT_VALUE = 100;
    public const int MAX_HEALTH = 9999;
    
    public int level;

    public int exp;

    public int[] expToLevelUp;
    [Tooltip("Vida max del jugador por level")]
    public int[] hpLevels;
    [Tooltip("Daño que se suma a la del arma por level")]
    public int[] strengthLevels;
    [Tooltip("Defensa que divide al daño del enemigo")]
    public int[] defenseLevels;
    [Tooltip("Velocidad de ataque")]
    public int[] speedLevels;    
    [Tooltip("Probabilidad de que el enemigo falle")]
    public int[] luckLevels;
    [Tooltip("Probabilidad de que falle el personaje")]
    public int[] accuracyLevels;

    private HealthManager _healthManager;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _playerController = GetComponent<PlayerController>();
        
        _healthManager.UpdateMaxHealth(hpLevels[level]);
        if (gameObject.CompareTag("Enemy"))
        {
            EnemyController controller = GetComponent<EnemyController>();
            controller.speed += speedLevels[level] / MAX_STAT_VALUE;
        }
    }


    public void AddExperiencie(int exp)
    {
        this.exp += exp;
        
        if (level >= expToLevelUp.Length)
        {
            return;
        }
        
        if (this.exp >= expToLevelUp[level])
        {
            level++;
            _healthManager.UpdateMaxHealth(hpLevels[level]);
            _playerController.attackTime -= speedLevels[level]/MAX_STAT_VALUE;
        }
    }
}
