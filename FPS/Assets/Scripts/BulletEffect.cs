using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletEffect : ShootingEffect
{
    public GameObject Bullet;
    public float Force = 30f;

    public override void BeginEffect(GameObject owner)
    {
        GameObject bullet = Instantiate(Bullet, Camera.main.transform.position, Camera.main.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Force;
    }
}