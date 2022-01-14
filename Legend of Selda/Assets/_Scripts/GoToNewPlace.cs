using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Name Here!!!";

    public bool needClick;

    public string uuid;

    private PlayerController _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {   
        LoadScene(col.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D col)
    { 
        LoadScene(col.gameObject.name);
    }

    /// <summary>
    /// Load new scene using variable "newPlaceName"
    /// </summary>
    /// <param name="colName">Name of collision</param>
    private void LoadScene(string colName)
    {
        if (colName == "Player")
        {
            if(!needClick || needClick && Input.GetMouseButtonDown(0))
            {
                _player.nextUuid = uuid;
                SceneManager.LoadScene(newPlaceName);
            }
        }
    }
}
