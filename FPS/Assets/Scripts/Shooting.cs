using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class Shooting : MonoBehaviour
{
    private Bullet bullet;
    public GameObject pistol;

    public float AtkDistance;
    public ShootingEffect[] OnAttackComplete;

    void Start()
    {
        bullet = GetComponent<Bullet>();
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, AtkDistance))
        {
            pistol.transform.LookAt(hit.point);
        }
        else
        {
            pistol.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void Attack()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, AtkDistance))
        {
            GameObject eHit = hit.collider.gameObject;
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


