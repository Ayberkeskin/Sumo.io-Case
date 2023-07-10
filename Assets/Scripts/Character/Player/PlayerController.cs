using Input;
using UnityEngine;


public class PlayerController : CharacterController
{
    [SerializeField] InputData ýnput;
    protected override void Look(Vector3 lookDirection)
    {
        modelTransform.forward = Vector3.Lerp(modelTransform.forward, lookDirection, Time.fixedDeltaTime * characterData.RotationSpeed);
    }

    protected override void Move()
    {
        Look(ýnput.Direction);
        rb.velocity = (modelTransform.forward * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
    }
  

}
