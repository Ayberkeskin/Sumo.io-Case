using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData ýnput;
        [SerializeField] FloatingJoystick joystick;


        private void Update()
        {
            ýnput.Horizontal = joystick.Horizontal;
            ýnput.Vertical = joystick.Vertical;
        }
    }

}
