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

    private void Start()
    {
        CloseDialogue();
    }

    // Update is called once per frame
    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            CloseDialogue();
        }
    }

    public void ShowDialogue(string text)
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = text;
    }

    public void ShowDialogue(string text, Sprite sprite)
    {
        ShowDialogue(text);
        avatarImage.enabled = true;
        avatarImage.sprite = sprite;
    }

    public void CloseDialogue()
    {
        dialogueActive = false;
        avatarImage.enabled = false;
        dialogueBox.SetActive(false);
    }
}
