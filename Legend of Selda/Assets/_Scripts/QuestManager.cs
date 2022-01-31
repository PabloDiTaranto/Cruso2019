using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;

    private DialogueManager _dialogueManager;

    public QuestItem itemCollected;
    
    public QuestEnemy enemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        foreach (Transform t in transform)
        {
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
    }
    
    public void ShowQuestText(string questText)
    {
        _dialogueManager.ShowDialogue(new string[]{questText});
    }

    public Quest QuestWithID(int questID)
    {
        Quest q = null;
        foreach (Quest temp in quests)
        {
            if (temp.questID == questID)
            {
                q = temp;
                break;
            }
        }

        return q;
    }
}
