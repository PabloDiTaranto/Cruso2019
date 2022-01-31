using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{

    public int questID;

    private QuestManager _questManager;

    private ItemsManager _itemsManager;

    public string itemName;
    
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _questManager = FindObjectOfType<QuestManager>();
            _itemsManager = FindObjectOfType<ItemsManager>();
            Quest q = _questManager.QuestWithID(questID);
            if (q == null)
            {
                Debug.LogErrorFormat("La mision con ID {0} no existe", questID);
                return;
            }
            if (q.gameObject.activeInHierarchy && !q.questCompleted)
            {
                _questManager.itemCollected = this;
                _itemsManager.AddQuestItem(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
