using Input;
using UnityEngine;


public class PlayerController : CharacterController
{
    [SerializeField] InputData ýnput;
    [SerializeField] GameManager _gameManager;
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
            Look(ýnput.Direction);
            rb.velocity = (modelTransform.forward * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
        }
      
      
    }
  

}
