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
    public bool showLossScreen = false;
    
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
                GameOver(true);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
