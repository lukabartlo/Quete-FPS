using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask WhatIsGround, WhatIsPlayer;

    public GameObject Projectile;

    public EnemyStat enemyStat;

    public Vector3 walkpoint;
    bool walkPointSet;
    public float WalkPointRange;

    public float TimeBetweenAttacks;
    bool alreadyAttacked;

    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!PlayerInSightRange && !PlayerInAttackRange) 
        {
            Patroling();
        }
        else if (PlayerInSightRange && !PlayerInAttackRange)
        {
            ChasePlayer();
        }
        else if (PlayerInSightRange && PlayerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }
        else if (walkPointSet) 
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f) 
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() 
    {
        float RandomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float RandomX = Random.Range(-WalkPointRange, WalkPointRange);

        walkpoint = new Vector3(transform.position.x + RandomX, transform.position.z + RandomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, WhatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked) 
        { 
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDmg(float BulletDmg)
    {
        enemyStat.CurrentHp -= BulletDmg;
        if (!IsAlive())
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsAlive()
    {
        return enemyStat.CurrentHp > 0;
    }
}
