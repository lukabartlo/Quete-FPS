using UnityEngine;

public class EnemyBulletEffect : ShootingEffect
{
    public GameObject EnemyBullet;
    public GameObject pistol;
    public float Force = 30f;

    public override void BeginEffect(GameObject owner)
    {
        GameObject enemyBullet = Instantiate(EnemyBullet, pistol.transform.position, pistol.transform.rotation);
        enemyBullet.GetComponent<Rigidbody>().velocity = enemyBullet.transform.forward * Force;
    }
}
