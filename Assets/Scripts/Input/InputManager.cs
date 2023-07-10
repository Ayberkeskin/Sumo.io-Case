using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData �nput;
        [SerializeField] FloatingJoystick joystick;


        private void Update()
        {
                �nput.Horizontal = joystick.Horizontal;
                �nput.Vertical = joystick.Vertical;
                �nput.Direction = new Vector3(�nput.Horizontal, 0, �nput.Vertical);    
        }
    }

}
