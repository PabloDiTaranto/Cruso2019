using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{
    public string npcName, npcDialogue;

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
            string finalDialogue = (npcName != null ? npcName + "\n" : "") + npcDialogue;
            
            if (npcSprite != null)
            {
                _dialogueManager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            {
                _dialogueManager.ShowDialogue(finalDialogue);
            }
        }
    }
}
