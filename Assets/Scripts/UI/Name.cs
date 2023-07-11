using UnityEngine;

public class Name : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation= _camera.transform.rotation;
    }

}
