using Input;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] InputData �nput;
    protected override void Look(Vector3 lookDirection)
    {
        _modelTransform.forward = Vector3.Lerp(_modelTransform.forward, lookDirection, Time.fixedDeltaTime * characterData.RotationSpeed);
    }

    protected override void Move()
    {
        Look(�nput.Direction);
        _rb.velocity = (_modelTransform.forward * characterData.MoveSpeed) + (Vector3.up * _rb.velocity.y);
    }
}
