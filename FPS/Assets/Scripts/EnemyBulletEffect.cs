using UnityEngine;

public class EnemyBulletEffect : ShootingEffect
{
    public GameObject EnemyBullet;
    public GameObject Enemypistol;
    public float Force = 30f;

    public override void BeginEffect(GameObject owner)
    {
        GameObject enemyBullet = Instantiate(EnemyBullet, Enemypistol.transform.position, Enemypistol.transform.rotation);
        enemyBullet.GetComponent<Rigidbody>().velocity = enemyBullet.transform.forward * Force;
    }
}
