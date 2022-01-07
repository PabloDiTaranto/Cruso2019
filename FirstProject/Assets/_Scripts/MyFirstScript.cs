using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public int x = 4;

    public int y = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        AddTwoNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds the two numbers.
    /// </summary>
    private void AddTwoNumbers()
    {
        Debug.Log(x+y);
    }
}
