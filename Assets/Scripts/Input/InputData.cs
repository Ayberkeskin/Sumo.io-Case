using UnityEngine;

namespace Input
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Input Data")]
    public class InputData : ScriptableObject
    {
        [SerializeField] float _horizontal;
        [SerializeField] float _vertical;
        [SerializeField] Vector3 _direction;

        public float Horizontal { get => _horizontal; set => _horizontal = value; }
        public float Vertical { get => _vertical; set => _vertical = value; }
        public Vector3 Direction { get => _direction; set => _direction = value; }
    }

}
