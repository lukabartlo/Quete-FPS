using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletEffect : ShootingEffect
{
    public GameObject Bullet;
    public GameObject pistol;
    public float Force = 5f;

    public override void BeginEffect(GameObject owner)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 DirectionWithoutSpread = targetPoint - pistol.transform.position;


        GameObject bullet = Instantiate(Bullet, pistol.transform.position, pistol.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(DirectionWithoutSpread * Force, ForceMode.Impulse);
    }
}
