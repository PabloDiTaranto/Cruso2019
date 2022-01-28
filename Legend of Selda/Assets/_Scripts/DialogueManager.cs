using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Image avatarImage;
    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentDialogueLine;

    private PlayerController _playerController;
    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        CloseDialogue();
    }

    // Update is called once per frame
    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogueLine++;
            
            if (currentDialogueLine >= dialogueLines.Length)
            {
                CloseDialogue();
            }
            else
            {
                dialogueText.text = dialogueLines[currentDialogueLine];
            }
        }
    }

    public void ShowDialogue(string[] lines)
    {
        currentDialogueLine = 0;
        dialogueLines = lines;
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentDialogueLine];
        _playerController.isTalking = true;
    }

    public void ShowDialogue(string[] lines, Sprite sprite)
    {
        ShowDialogue(lines);
        avatarImage.enabled = true;
        avatarImage.sprite = sprite;
    }

    public void CloseDialogue()
    {
        _playerController.isTalking = false;
        currentDialogueLine = 0;
        dialogueActive = false;
        avatarImage.enabled = false;
        dialogueBox.SetActive(false);
    }
}
