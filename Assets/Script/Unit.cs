using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    
    public bool takeDamage(int otherDamage)
    {
        currentHealth -= otherDamage;
        if (currentHealth <= 0)
        {
            return true;
        }
        else return false;
    }
}
