using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float MaxAtk = 1;

    public float MaxHp = 50;

    public float MaxSpeed = 20;

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentSPD { get; private set; }

    public void Start()
    {
        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentSPD = MaxSpeed;
    }

    public void TakeDmg(float BulletDmg)
    {
        CurrentHp -= BulletDmg;
    }

    public bool IsAlive()
    {
        return CurrentHp > 0;
    }
}
