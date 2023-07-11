using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : CharacterController
{

    [SerializeField] private GameManager _gameManager;

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> points = new List<GameObject>();
    private RaycastHit[] raycastHits = new RaycastHit[30];

    [SerializeField] private LayerMask _layer;

    public GameObject targetEnemy;
    public GameObject targetPoint;


    private void FixedUpdate()
    {

        Search();
        Move();
    }

    protected override void Attack(Collision collision)
    {
        if (this.gameObject.GetComponent<CharacterController>()._power > collision.gameObject.GetComponent<CharacterController>()._power)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-(transform.position - collision.transform.position) * 2000f * Time.deltaTime, ForceMode.Impulse);
        }
        else if (this.gameObject.GetComponent<CharacterController>()._power == collision.gameObject.GetComponent<CharacterController>()._power)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-(transform.position - collision.transform.position) * 1200f * Time.deltaTime, ForceMode.Impulse);
            gameObject.GetComponent<Rigidbody>().AddForce(-(collision.transform.position - transform.position) * 1200f * Time.deltaTime, ForceMode.Impulse);
        }
        else if (this.gameObject.GetComponent<CharacterController>()._power < collision.gameObject.GetComponent<CharacterController>()._power)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-(collision.transform.position - transform.position) * 2000f * Time.deltaTime, ForceMode.Impulse);
        }
        StartCoroutine(EnemyAttack());
    }


    IEnumerator EnemyAttack()
    {
        animator.SetBool(CharacterAnimationsStrings.AttackStr, true);
        yield return new WaitForSeconds(.3f);
        animator.SetBool(CharacterAnimationsStrings.AttackStr, false);
    }
    protected override void Move()
    {
        Vector3 look;
        FindNearestEnemy(targets.Count);
        if (_gameManager.isStart)
        {
            animator.SetBool(CharacterAnimationsStrings.MoveStr, true);
            transform.Translate(Vector3.forward * characterData.MoveSpeed * Time.fixedDeltaTime);
            if (gameObject != null && gameObject.GetComponent<CharacterController>() != null && targetEnemy != null && gameObject.GetComponent<CharacterController>()._power > targetEnemy.GetComponent<CharacterController>()._power)
            {
                look = new Vector3(targetEnemy.gameObject.transform.position.x, 0, targetEnemy.gameObject.transform.position.z);

            }
            else
            {
                look = new Vector3(targetPoint.transform.position.x, 0, targetPoint.transform.position.z);
            }

            Look(look);
        }
    }



    protected override void Look(Vector3 lookDirection)
    {
        if (_gameManager.isStart)
        {
            transform.LookAt(lookDirection);
        }
    }
    // Düþmanýn hedeflerini aramak için fonksiyon
    private void Search()
    {
        int random = Random.Range(0, 2);
        int hitCount = Physics.SphereCastNonAlloc(modelTransform.position, 300f, Vector3.up, raycastHits, Mathf.Infinity, _layer);
        if (hitCount < 0)
        {
            targetEnemy = null;
            targetPoint = null;
            return;
        }


        Transform nearestTransform = FindNearestTransform(hitCount);
    }
    // En yakýn hedefi bulan foksiyon
    private Transform FindNearestTransform(int hitCount)
    {
        Transform nearestTransform = raycastHits[0].transform;
        for (int i = 1; i < hitCount; i++)
        {
            Transform nextTransform = raycastHits[i].transform;

            float nearestTargetDistance = (modelTransform.position - nearestTransform.position).sqrMagnitude;
            float nextTargetDistance = (modelTransform.position - nextTransform.position).sqrMagnitude;

            if (nextTargetDistance < nearestTargetDistance)
            {
                nearestTransform = nextTransform;
            }

        }
        targetPoint = nearestTransform.gameObject;
        return nearestTransform;
    }

    // En yakýn düþmaný bulan foksiyon
    private Transform FindNearestEnemy(int count)
    {
        if (targets[0].gameObject != null)
        {
            Transform nearestTransform = targets[0].transform;

            for (int i = 1; i < count; i++)
            {
                if (targets[i].gameObject != null)
                {
                    Transform nextTransform = targets[i].transform;

                    float nearestTargetDistance = (modelTransform.position - nearestTransform.position).sqrMagnitude;
                    float nextTargetDistance = (modelTransform.position - nextTransform.position).sqrMagnitude;

                    if (nextTargetDistance < nearestTargetDistance)
                    {
                        nearestTransform = nextTransform;
                    }
                }

            }
            targetEnemy = nearestTransform.gameObject;
            return nearestTransform;

        }
        return null;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            PowerUp();
            objectPool.SetPoolObject(collision.gameObject);
        }
        else if (collision.gameObject.tag == "enemy")
        {
            Attack(collision);
        }
        else if (collision.gameObject.tag == "player")
        {
            Attack(collision);
        }
    }
}