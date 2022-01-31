using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public enum ItemType{WEAPON = 0, ITEM = 1, ARMOR = 2, RING = 3, SPECIAL_ITEMS = 4}
    
    public int itemIdx;

    public ItemType type;


    public void ActivateButton()
    {
        switch (type)   
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemIdx);
                FindObjectOfType<UIManager>().inventoryText.text = 
                    FindObjectOfType<WeaponManager>().GetWeaponAt(itemIdx).weaponName;
                break;
            
            case ItemType.ITEM:
                Debug.Log("No implementado");
                break;
            
            case ItemType.ARMOR:
                Debug.Log("No implementado");
                break;
            
            case ItemType.RING:
                Debug.Log("No implementado");
                break;
            
            case ItemType.SPECIAL_ITEMS:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemIdx);
                FindObjectOfType<UIManager>().inventoryText.text = item.itemName;
                break;
        }
    }
}
