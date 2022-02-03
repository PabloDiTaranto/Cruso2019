using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    public int activeWeapon;
    
    private List<GameObject> armors;
    public int activeArmor;
    
    private List<GameObject> rings;
    public int activering1, activeRing2;
    
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
            
        foreach (Transform weapon in transform)
        {
            weapons.Add(weapon.gameObject);
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }

        armors = new List<GameObject>();

        rings = new List<GameObject>();
    }

    public void ChangeWeapon(int newWeapon)
    {
        weapons[activeWeapon].SetActive(false);
        weapons[newWeapon].SetActive(true);
        activeWeapon = newWeapon;
        
        FindObjectOfType<UIManager>().ChangeAvatarImage(weapons[activeWeapon].GetComponent<SpriteRenderer>().sprite);
    }

    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }

    public WeaponDamage GetWeaponAt(int pos)
    {
        return weapons[pos].GetComponent<WeaponDamage>();
    }
    
    public List<GameObject> GetAllArmors()
    {
        return armors;
    }
    
    public GameObject GetArmorAt(int pos)
    {
        return armors[pos];
    }
    
    public List<GameObject> GetAllRings()
    {
        return rings;
    }
    
    public GameObject GetRingAt(int pos)
    {
        return rings[pos];
    }
}
