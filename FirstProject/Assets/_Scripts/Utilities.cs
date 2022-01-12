using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths = 0;
    
    public static void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Muertes del juagdor: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Muertes totales: " + playerDeaths);
    }

    public static string UpdateDeathCount(ref int countRef)
    {
        countRef++;
        return "Has jugado ya: " + countRef;
    }
}
