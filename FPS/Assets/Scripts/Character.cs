using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BaseStats stats;

    public float MaxAtk { get; private set; }

    public float MaxHp { get; private set; }

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; set; }

    public float PercentAtk = 100f;
    public float PercentHp = 100f;

    public float CDShooting;

    //[HideInInspector] public bool CanTakeDamage = true;

    private void Start()
    {
        CharacterStats();
    }

    //public void SetCanTakeDamage(bool enable) => CanTakeDamage = enable;

    public void CharacterStats()
    {
        stats = GetComponent<BaseStats>();

        MaxAtk = stats.Atk * PercentAtk / 100;
        MaxHp = stats.Hp * PercentHp / 100;

        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
    }

    /*public void TakeDmg(float enemyDMG)
    {
        if (!CanTakeDamage)
            return;

        CurrentHp -= enemyDMG;
    }*/

    public void SetHealthPoint(float newHealthPoint)
    {
        CurrentHp = newHealthPoint;
    }

    public bool IsAlive() 
    {
        return CurrentHp > 0;
    }
}
