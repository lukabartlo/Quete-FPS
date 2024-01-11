using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float BulletDamage = 5f;

    public Action<EnemyStat> onEnemyKill;

    public float Lifespan = 1.5f;

    public void Start()
    {
        Destroy(this.gameObject, Lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<EnnemyAI>(out var stat))
        {
            stat.TakeDmg(BulletDamage);
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
