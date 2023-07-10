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
                ýnput.Direction = new Vector3(ýnput.Horizontal, 0, ýnput.Vertical);    
        }
    }

}
