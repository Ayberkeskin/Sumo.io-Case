using System.Collections;
using UnityEngine;
using Cinemachine;

public class CinemaMachineController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    public GameObject Player;



    public void SetCameraShake()
    {
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = .5f;
        StartCoroutine(nameof(CameraShake));
    }



    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(0.3f);
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }

}
