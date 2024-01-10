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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<EnemyStat>(out var stat))
        {
            stat.TakeDmg(BulletDamage);
            if (!stat.IsAlive())
            {
                onEnemyKill?.Invoke(stat);
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
