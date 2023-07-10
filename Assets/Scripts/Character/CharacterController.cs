using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;

    public Rigidbody _rb;

    public Transform _modelTransform;

    private void FixedUpdate()
    {
        Move();
    }
    protected abstract void Move();

    protected abstract void Look(Vector3 lookDirection);
}
