using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class Shooting : MonoBehaviour
{
    private Bullet bullet;

    public float AtkDistance;
    public ShootingEffect[] OnAttackComplete;

    void Start()
    {
        bullet = GetComponent<Bullet>();
    }

    public void Attack()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, AtkDistance))
        {
            GameObject eHit = hit.collider.gameObject;
            if (eHit.TryGetComponent<EnemyStat>(out var stat))
            {
                stat.TakeDmg(bullet.BulletDamage);
            }
        }

        if (OnAttackComplete.Length > 0)
        {
            foreach (ShootingEffect effect in OnAttackComplete)
            {
                effect.BeginEffect(this.gameObject);
            }
        }
    }
}


