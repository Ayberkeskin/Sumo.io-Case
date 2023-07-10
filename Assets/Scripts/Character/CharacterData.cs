using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character Data")]
public class CharacterData : ScriptableObject
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotationSpeed;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
}
