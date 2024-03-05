using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{
    public enum Camera_Rotation
    {
        ON,
        OFF
    }
    [SerializeField] private Camera_Rotation cameraRotation;
    
    [Space]    
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rotationSpeed = 1.0f;

    private void Update()
    {
        if (cameraRotation == Camera_Rotation.ON)
        {
            AutoRotate();
        }
    }

    private void AutoRotate()
    {
        cameraTransform.Rotate(0, rotationSpeed, 0);
    }

    public void OnRotation (Toggle _toggle)
    {
        if (_toggle.isOn)
        {
            cameraRotation = Camera_Rotation.ON;
        }
        else
        {
            cameraRotation = Camera_Rotation.OFF;
        }
    }
}
