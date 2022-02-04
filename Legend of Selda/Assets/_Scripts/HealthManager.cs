using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    
    private int _currentHealth;

    public int Health
    {
        get
        {
            return _currentHealth;
        }
    }

    public bool flashActive;
    public float flashLenght;
    private float flashCounter;

    private SpriteRenderer _spriteRenderer;

    public int expWhenDefeated;

    private QuestEnemy quest;
    private QuestManager _questManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _questManager = FindObjectOfType<QuestManager>();
        quest = GetComponent<QuestEnemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (flashActive)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter > flashLenght * 0.66f)
            {
                ToggleColor(false);
            }else if (flashCounter > flashLenght * .33f)
            {
                ToggleColor(true);
            }else if (flashCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                flashActive = false;
                GetComponent<BoxCollider2D>().enabled = true;           
                GetComponent<PlayerController>().canMove = true;

            }
        }
    }

    public void DamageCharacter(int damage)
    {
        SFXManager.SharedInstance.PlaySFX(SFXType.SoundType.HIT);
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            if (expWhenDefeated > 0)
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperiencie(expWhenDefeated);
                _questManager.enemyKilled = quest;
            }

            if (gameObject.CompareTag("Player"))
            {
                SFXManager.SharedInstance.PlaySFX(SFXType.SoundType.DIE);
            }
            
            gameObject.SetActive(false);
        }

        if (flashLenght > 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
            flashActive = true;
            flashCounter = flashLenght;
        }
        
    }

    /// <summary>
    /// update MaxHealth with int feed
    /// </summary>
    /// <param name="newMaxHealth">New health max</param>
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        _currentHealth = maxHealth;
    }

    private void ToggleColor(bool visible)
    {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r,
                                            _spriteRenderer.color.g,
                                            _spriteRenderer.color.b,
                                            (visible?1f:0.2f));
    }
}
