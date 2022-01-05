
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject ShotPos;

    public GameObject EnemyGun;

    public GameObject ammoDrop, healthDrop, enemyBody;

    

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, isAlive;
    // private NavMeshAgent n;

    private void Awake()
    {
        // n = GetComponent<NavMeshAgent>();
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
        isAlive = true;
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(isAlive){
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
        // else{
        //     // n.velocity = new Vector3(0,0,0);
        //     Debug.Log("Entered Log when dead");
        //     // transform.position();
        //     // n.isStopped = true;
        //     // n.velocity = Vector3.zero;
        //     return;
        // }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        Vector3 PlayerIsSameHeight = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        
        // Transform newLook = player.transform; // new Vector3(transform.rotation.x, player.transform.rotation.y, transform.rotation.z);
        // newLook.transform.rotation = Quaternion.Euler(transform.rotation.x, player.transform.rotation.y, transform.rotation.z);// new Vector3(0,0,0);
        // transform.LookAt( newLook);

        transform.LookAt(PlayerIsSameHeight);

        // transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z);// new Vector3(0,0,0);

        if (alreadyAttacked == false)
        {
            alreadyAttacked = true;
            Invoke("FirePlayer", timeBetweenAttacks);

        }        
 

        //if (!alreadyAttacked)
        //{
        //    ///Attack code here
        //    Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //    rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //    rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        //    ///End of attack code

        //    alreadyAttacked = true;
        //    if (IsInvoking("ResetAttack"))
        //    {
        //        Invoke("ResetAttack", timeBetweenAttacks);
        //    }
        //}
    }
    public void FirePlayer()
    {
        GameObject Bullet = Instantiate(projectile, ShotPos.transform.position, Quaternion.identity);
        Vector3 ScaleBullet = new Vector3(0.1f, 0.1f, 0.1f);
        Bullet.transform.localScale = ScaleBullet;
        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        rb.AddForce(ShotPos.transform.forward * 50f, ForceMode.Impulse);
        Debug.Log("enemyattack");
        alreadyAttacked = false;

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        Debug.Log("enemyattack");
        CancelInvoke();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("enemyTakeDamage");

        if (health <= 0)
        {
            int rand = Random.Range(0, 9);
            if(rand < 7){
                Debug.Log("make Ammo");
                // GameObject ammoBox = Instantiate(ammoDrop, ShotPos.transform.position, Quaternion.identity);
                // ammoBox.transform.localPosition = transform.position;
                ammoDrop.SetActive(true);
                ammoDrop.transform.parent = null;
            }
            else{
                Debug.Log("make Health");
                // GameObject healthBox = Instantiate(healthDrop, ShotPos.transform.position, Quaternion.identity);
                // healthBox.transform.localPosition = transform.position;
                healthDrop.SetActive(true);
                healthDrop.transform.parent = null;
            }
            Invoke(nameof(DestroyEnemy), 0.5f);
            
        }
    }
    private void DestroyEnemy()
    {
        isAlive = false;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isAlive", false);
        // StartCoroutine(Coroutine(2));
        
        // GetComponent<Rigidbody>().freezeRotation = true;
        // GetComponent<Rigidbody>().position = ;
        EnemyGun.SetActive(false);
        StartCoroutine(Coroutine());
        // Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator Coroutine(){
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
