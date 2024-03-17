using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Runtime.Project.Level.Scripts.Manager
{
    public enum EnemyState
    {
        Idle,
        MoveTarget,
        Attacking,
        Dead
    }
    
    public class Enemy : MonoBehaviour
    {
        public Transform Target;

        public NavMeshAgent Agent;

        public float Intelligence = 1;

        public float ViewRange;

        public EnemyState State;
        
        
        private IEnumerator _think;

        private void Start()
        {
            _think = Think();
            StartCoroutine(_think);
        }

        private IEnumerator Think()
        {
            while (State != EnemyState.Dead)
            {
                yield return new WaitForSeconds(Intelligence);

                FindTarget();

                switch (State)
                {
                    case EnemyState.Idle:
                        IdleMove();
                        break;
                    case EnemyState.MoveTarget:
                        MoveTarget();
                        break;
                    case EnemyState.Attacking:
                        yield return new WaitForSeconds(.5f); 
                        State = EnemyState.MoveTarget;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

       

        private void MoveTarget()
        {
            Agent.SetDestination(Target.position);
            var distance = Vector3.Distance(Target.position, transform.position);

            if (distance < 2)
            {
                State = EnemyState.Attacking;
                Debug.Log("atak");
            }
        }
        

        private void IdleMove()
        {
            var newTarget = new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
            Agent.SetDestination(newTarget);
        }
        
        
            
        

        private void FindTarget()
        {
            var distance = Vector3.Distance(Target.position, transform.position);

            if (distance < ViewRange )
            {
                State = EnemyState.MoveTarget;
            }
            else
            {
                State = EnemyState.Idle;
            }
        }
        
    }
}
