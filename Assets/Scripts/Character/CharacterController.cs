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

    public float _totalScore = 0;

    public int _power = 300;

    private void FixedUpdate()
    {
        Move();
    }
    // Karakteri hareket ettir
    protected abstract void Move();

    // Karakterin saldýrýsýný gerçekleþtir
    protected abstract void Attack(Collision collision);

    // Karakterin bakýþ yönünü ayarla
    protected abstract void Look(Vector3 lookDirection);

    // Güç seviyesini arttýr (Ortak olduðu için virtual)
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
    // Karakter ölümü(Ortak olduðu için virtual)
    protected virtual void Death()
    {
        Destroy(gameObject);
        GameObject.FindObjectOfType<GameManager>().aliveCount -= 1;

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            
            Death();
        }
    }

}
