using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class EnnemyBullet : MonoBehaviour
{
    public float EnemyBulletDMG = 5f;

    public float Lifespan = 1.5f;

    public void Start()
    {
        Destroy(this.gameObject, Lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<Character>(out var stat))
        {
            stat.TakeDmg(EnemyBulletDMG);
            if (!stat.IsAlive())
            {
                Destroy(gHit);
            }
        }
        DestroyProjectiles();
    }

    private void DestroyProjectiles()
    {
        Destroy(this.gameObject);
    }
}
