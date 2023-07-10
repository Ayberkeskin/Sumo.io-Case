using Input;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : CharacterController
{
    [SerializeField] InputData ýnput;
    [SerializeField] GameManager _gameManager;

    protected override void Attack(Collision collision)
    {
        if (_power>collision.gameObject.GetComponent<CharacterController>()._power)
        {
            collision.rigidbody.AddForce(-(transform.position - collision.transform.position) * _power * Time.deltaTime, ForceMode.Impulse);
        }
        else if (_power == collision.gameObject.GetComponent<CharacterController>()._power)
        {
            collision.rigidbody.AddForce(Vector3.zero);
        }
        else
        {
            rb.AddForce(-(transform.position - collision.transform.position) * _power * Time.deltaTime, ForceMode.Impulse);
        }
        
        StartCoroutine(PlayerAttack());
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
            rb.velocity = (modelTransform.forward * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
        }
    }

    IEnumerator PlayerAttack()
    {
        animator.SetBool(CharacterAnimationsStrings.AttackStr, true);
        yield return new WaitForSeconds(.3f);
        animator.SetBool(CharacterAnimationsStrings.AttackStr, false);
    }
    

}
