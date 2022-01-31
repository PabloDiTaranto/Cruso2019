using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public int questID;
    
    public bool questCompleted, needsItem, killsEnemies;
    
    private QuestManager _questManager;
    
    public string title, startText, completeText;

    public List<QuestItem> itemsNeeded;

    public List<QuestEnemy> enemies;
    public List<int> numberOfEnemies;

    public Quest nextQuest;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (needsItem)
        {
            ActivateItems();
        }

        if (killsEnemies)
        {
            ActivateEnemies();
        }
    }

    public void StartQuest()
    {
        _questManager = FindObjectOfType<QuestManager>();
        _questManager.ShowQuestText(title + "\n" + startText);

        if (needsItem)
        {
            ActivateItems();
        }

        if (killsEnemies)
        {
            ActivateEnemies();
        }
    }

    private void ActivateItems()
    {
        QuestItem[] items = Resources.FindObjectsOfTypeAll<QuestItem>();
        foreach (QuestItem item in items)
        {
            if (item.questID == questID)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    private void ActivateEnemies()
    {
        QuestEnemy[] qEnemies = Resources.FindObjectsOfTypeAll<QuestEnemy>();
        foreach (QuestEnemy enemy in qEnemies)
        {
            if (enemy.questID == questID)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }

    public void CompleteQuest()
    {
        Debug.Log("Quest completed");
        _questManager = FindObjectOfType<QuestManager>();
        _questManager.ShowQuestText(title + "\n" + completeText);
        questCompleted = true;
        if (nextQuest != null)
        {
            Debug.Log("Next Quest");
            Invoke("ActivateNextQuest", 5.0f);
        }
        gameObject.SetActive(false);
    }

    private void ActivateNextQuest()
    {
        nextQuest.gameObject.SetActive(true);
        nextQuest.StartQuest();
    }

    private void Update()
    {
        if (needsItem && _questManager.itemCollected != null)
        {
            for (int i = 0; i < itemsNeeded.Count; i++)
            {
                if (itemsNeeded[i].itemName == _questManager.itemCollected.itemName)
                {
                    itemsNeeded.RemoveAt(i);
                    _questManager.itemCollected = null;
                    break;
                }
            }

            if (itemsNeeded.Count == 0)
            {
                CompleteQuest();
            }
        }

        if (killsEnemies && _questManager.enemyKilled != null)
        {
            Debug.Log("Tenemos un enemigo recien matado");
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].enemyName == _questManager.enemyKilled.enemyName)
                {
                    numberOfEnemies[i]--;
                    _questManager.enemyKilled = null;
                    if (numberOfEnemies[i] <= 0)
                    {
                        enemies.RemoveAt(i);
                        numberOfEnemies.RemoveAt(i);
                    }
                    break;
                }
            }

            if (enemies.Count == 0)
            {
                CompleteQuest();
            }
        }
    }
}
