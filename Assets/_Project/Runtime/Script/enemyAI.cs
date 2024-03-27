using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.LowLevel;
using Random = UnityEngine.Random;

public class enemyAI : MonoBehaviour
{
    
    private GameObject player;
    private NavMeshAgent _agent;
    [SerializeField] private LayerMask groundLayer, playerLayer;
    private Vector3 destPoint;
    private bool walkpointSet;
    [SerializeField] private float range;
    [SerializeField] private float sightRange, attackRange;
    private bool playerInSight, playerInAttackRange;
    private Animator _animator;
    private BoxCollider SpiderNail;
    public DeathPanel panel;
        
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character");
        _animator = GetComponent<Animator>();
        SpiderNail = this.transform.Find("jtBn_spiderRoot/jtBn_head/jtBn_l_leg01_/jtBn_l_leg01_1/jtBn_l_leg01_2/SpiderNail1").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        
        if (!playerInSight && !playerInAttackRange) Patrol();
        if (playerInSight && !playerInAttackRange) Chase();
        if (playerInSight && playerInAttackRange) Attack();
    }

    void Attack()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Spider _ Attack"))
        {
            _animator.SetTrigger("Attack");
            _agent.SetDestination(transform.position);
        }
    }
    
    //Spider attacks
    void DealDamage() {
        Collider[] hitList = Physics.OverlapSphere(SpiderNail.transform.position, attackRange, playerLayer);
        foreach (var hits in hitList)
        {
            //hits.SendMessage("returnGame");
            panel.GetComponent<DeathPanel>().returnGame();
        }
    }
    
    void Chase()
    {
        _agent.SetDestination(player.transform.position);
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) _agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
