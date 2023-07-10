using UnityEngine;
using UnityEngine.UI;


public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;

    public PointData pointData;

    public ObjectPool objectPool;

    public Rigidbody rb;

    public Transform modelTransform;

    private float _totalScore=0;

    private int _power = 10;
     
    private void FixedUpdate()
    {
        Move();
    }
    protected abstract void Move();

    protected abstract void Look(Vector3 lookDirection);

    protected virtual void PowerUp()
    {
        _totalScore += pointData.Score;

        if (_totalScore >= 500 && _totalScore < 1000)
        {
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            _power = 20;
        }
        else if (_totalScore >= 1000 && _totalScore < 1500)
        {
            gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            _power = 30;
        }
        else if (_totalScore >= 1500)
        {
            gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            _power = 40;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            PowerUp();
            objectPool.SetPoolObject(collision.gameObject);
            
        }
    }
}
