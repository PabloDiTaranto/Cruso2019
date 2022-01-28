using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{
    public string npcName;
    public string[] npcDialogueLines;

    public Sprite npcSprite;

    private DialogueManager _dialogueManager;

    private bool playerInZone;
    
    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
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

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Input.GetMouseButtonDown(1))
        {
            string[] finalDialogue = new string[npcDialogueLines.Length];

            int i = 0;
            foreach (var line in npcDialogueLines)
            {
                finalDialogue[i++] = (npcName != null ? npcName + "\n" : "") + line;
            }
            
            
            if (npcSprite != null)
            {
                _dialogueManager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            {
                _dialogueManager.ShowDialogue(finalDialogue);
            }

            if (gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }
}
