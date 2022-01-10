using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    private void Start()
    {
        Character hero = new Character();
        hero.PrintCharacterStats();

        Character hero2 = hero;
        hero2.PrintCharacterStats();
        hero2.name = "Madonna";
        hero.PrintCharacterStats();
        hero2.PrintCharacterStats();

        Character heroine = new Character("Lara Croft", 10);
        heroine.PrintCharacterStats();

        Weapon sword = new Weapon("Super Sword", 10);
        sword.PrintWeaponStats();
        
        Weapon sword2 = sword;
        sword2.PrintWeaponStats();

        sword2.name = "Excalibur";
        sword2.damage = 255;
        
        sword.PrintWeaponStats();
        sword2.PrintWeaponStats();

        Paladin p = new Paladin();
        p.PrintCharacterStats();

        Paladin p2 = new Paladin("Arthas", sword);

        Archer archer = new Archer("Legolas", new Weapon("Arco del infierno", 15));

        Magician magician = new Magician("Gandalf");

        List<Character> party = new List<Character>();
        party.Add(p2);
        party.Add(archer);
        party.Add(magician);

        foreach (Character c in party)
        {
            c.PrintCharacterStats();
        }

        Transform theTransform = GetComponent<Transform>();
        Debug.Log(theTransform.position);
        Debug.Log(theTransform.rotation);
    }
}
