using UnityEngine;
using UnityEngine.UI;


public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;

    public PointData pointData;

    public ObjectPool objectPool;

    public Rigidbody rb;

    public Transform modelTransform;

    public Animator animator;

    public float _totalScore=0;

    public int _power = 300;
     
    private void FixedUpdate()
    {
        Move();
    }
    protected abstract void Move();

    protected abstract void Attack(Collision collision);

    protected abstract void Look(Vector3 lookDirection);

    protected virtual void PowerUp()
    {
        _totalScore += pointData.Score;

        if (_totalScore >= 500 && _totalScore < 1000)
        {
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            _power = 500;
        }
        else if (_totalScore >= 1000 && _totalScore < 1500)
        {
            gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            _power = 700;
        }
        else if (_totalScore >= 1500)
        {
            gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            _power = 900;
        }
    }
    protected virtual void Death()
    {
        Destroy(gameObject);

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            Death();
        }
    }

}
