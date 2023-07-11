using Input;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : CharacterController
{
    [SerializeField] InputData ýnput;
    [SerializeField] GameManager _gameManager;
    public float playerScore;

    private void Update()
    {
        playerScore = gameObject.GetComponent<CharacterController>()._totalScore;
    }
    protected override void Attack(Collision collision)
    {
        if (this.gameObject.GetComponent<CharacterController>()._power>collision.gameObject.GetComponent<CharacterController>()._power)
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
        StartCoroutine(PlayerAttack());
    }


    IEnumerator PlayerAttack()
    {
        animator.SetBool(CharacterAnimationsStrings.AttackStr, true);
        yield return new WaitForSeconds(.3f);
        animator.SetBool(CharacterAnimationsStrings.AttackStr, false);
    }
    protected override void Look(Vector3 lookDirection)
    {
        if (_gameManager.isStart)
        {
            modelTransform.forward = Vector3.Lerp(modelTransform.forward, lookDirection, Time.fixedDeltaTime * characterData.RotationSpeed);
        }
    }

    protected override void Move()
    {
        
        if (_gameManager.isStart)
        {
            animator.SetBool(CharacterAnimationsStrings.MoveStr,true);
            Look(ýnput.Direction);
            rb.velocity = (modelTransform.forward * (characterData.MoveSpeed+2)) + (Vector3.up * rb.velocity.y);
        }
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
    }

}
