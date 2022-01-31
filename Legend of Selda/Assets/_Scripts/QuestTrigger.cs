using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager _questManager;

    public int questID;

    public bool startPoint, endPoint;

    private bool playerInZone;

    public bool automaticCatch;
    
    // Start is called before the first frame update
    void Start()
    {
        _questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (automaticCatch || (!automaticCatch && Input.GetMouseButtonDown(1)))
            {
                Quest q = _questManager.QuestWithID(questID);
                if (q == null)
                {
                    Debug.LogErrorFormat("La mision con ID {0} no existe", questID);
                    return;
                }
                if (!q.questCompleted)
                {
                    if (startPoint)
                    {
                        if (!q.gameObject.activeInHierarchy)
                        {
                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }

                    if (endPoint)
                    {
                        if (q.gameObject.activeInHierarchy)
                        {
                            q.CompleteQuest();
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
