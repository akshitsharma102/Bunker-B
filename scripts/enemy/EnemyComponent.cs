using System.CodeDom;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyComponent : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform player;
        public LayerMask whatsground, whatsplayer;

        //Patroling
        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;
        //Attacking
        public float timeBetweenAttacks = 2f;
        bool Attacking;
        public Transform bullet;

        //States
        public float sightRange, attackRange;
        public bool PlayerInSight, playerInAttackRange;


        //attacking
        public GameObject projectile;
        private void Awake()
        {
            
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            PlayerInSight = Physics.CheckSphere(transform.position, sightRange, whatsplayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatsplayer);
            if (!PlayerInSight && !playerInAttackRange) { Patrolling(); }
            if (PlayerInSight && !playerInAttackRange) { ChasePlayer(); }
            if (PlayerInSight && playerInAttackRange) { AttackPlayer(); }
            

        }

        private void Patrolling()
        {
            if (!walkPointSet) searchWalkPoint();

            if (walkPointSet) agent.SetDestination(walkPoint);

            Vector3 DistToWalkPt = transform.position - walkPoint;

            //reached
            if(DistToWalkPt.magnitude  <1f)
            {
                walkPointSet = false;
            }
            
        }
        private void searchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatsground)) walkPointSet = true;
            
        }
        private void ChasePlayer()
        {
            agent.SetDestination(player.position);
            
        }
        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            
            if(!Attacking)
            {
                Attacking = true;
                Rigidbody rb = Instantiate(projectile, bullet.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                Invoke(nameof(resetAttack), timeBetweenAttacks);
                
            }
            
        }
        private void resetAttack()
        {
            Attacking = false;
           
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}
