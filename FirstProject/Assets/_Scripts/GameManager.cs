using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomExtentions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IManager
{
    public string labelText = "Recolecta 4 items y ganate la libertad";
    public const int MAX_ITEMS = 4;

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public delegate void DebugFromDelegate(string text);
    
    public DebugFromDelegate debug = Print;

    public static void Print(string  text)
    {
        Debug.Log(text);
    }
    
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

            if (_itemsCollected >= MAX_ITEMS)
            {
                GameOver(true);
            }
            else
            {
                labelText = "Item encontrado te faltan " +
                            (MAX_ITEMS - _itemsCollected);
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
                if (_playerHp <= 0)
                {
                    GameOver(false);
                }
                else
                {
                    labelText = "Ouch, me han dado...";
                }
            }
            Debug.LogFormat("HP: {0}", _playerHp);
        }
    }

    private string _state;
    public string State
    {
        get { return _state;}
        set { _state = value; }
    }

    public void Initialize()
    {
        
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(25, 25, 180, 25), "Vida: " + _playerHp);
        GUI.Box(new Rect(25, 65, 180, 25), "Items Recogidos: " + _itemsCollected);
        GUI.Box(new Rect(Screen.width/2 - 200, Screen.height - 50, 400, 50), labelText);
        if (showWinScreen)
        {
            ShowEndLevel("HAS GANADO");
        }

        if (showLossScreen)
        {
            ShowEndLevel("GAME OVER");
        }
    }

    private void ShowEndLevel(string message)
    {
        if (GUI.Button(new Rect(Screen.width/2 -200,
                    Screen.height/2 -100,
                    400, 200),
                    message))
        {
            Utilities.RestartCurrentLevel();
            Time.timeScale = 1;
        }
    }

    private void GameOver(bool gameWon)
    {
        labelText = gameWon? "Has encontrado todos los items" : "Has Muerto. Prueba otra vez";
        showWinScreen = gameWon;
        showLossScreen = !gameWon;
        Time.timeScale = 0;
    }

    private void Start()
    {
        debug("hola");
    }
}
