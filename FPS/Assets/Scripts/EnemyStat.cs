using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float MaxAtk = 1f;

    public float MaxHp = 30f;

    public float MaxSpeed = 20f;

    public float CurrentAtk;

    public float CurrentHp;

    public float CurrentSPD;

    public void Start()
    {
        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentSPD = MaxSpeed;
    }



    
}
