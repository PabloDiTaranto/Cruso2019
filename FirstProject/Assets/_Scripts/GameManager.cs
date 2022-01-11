using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string labelText = "Recolecta 4 items y ganate la libertad";
    public int maxItems = 4;

    public bool showWinScreen = false;
    
    private int _itemsCollected = 0;
    public int ItemsCollected
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "Has encontrado todos los items";
                showWinScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Item encontrado te faltan " +
                            (maxItems - _itemsCollected);
            }
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
    
    private int _playerHp = 3;
    public int PlayerHp
    {
        get
        {
            return _playerHp;
        }
        set
        {
            if (value >= 0 && value <= 3)
            {
                _playerHp = value;
            }
            Debug.LogFormat("HP: {0}", _playerHp);
        }
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(25, 25, 180, 25), "Vida: " + _playerHp);
        GUI.Box(new Rect(25, 65, 180, 25), "Items Recogidos: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width/2 - 100, Screen.height - 50, 200, 50), labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 -200,
                        Screen.height/2 -100,
                        400, 200),
                        "Has Ganado"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }
}
