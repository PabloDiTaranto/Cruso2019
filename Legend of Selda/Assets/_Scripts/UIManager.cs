using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealtText;
    public HealthManager playerHealthManager;
    
    // Update is called once per frame
    void Update()
    {
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.Health;

        StringBuilder stringBuilder = new StringBuilder().
            Append("HP: ").
            Append(playerHealthManager.Health).
            Append(" / ").
            Append(playerHealthManager.maxHealth);

        playerHealtText.text = stringBuilder.ToString();
    }
}
