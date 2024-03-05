using UnityEngine;

public class Furniture_Rotation : MonoBehaviour
{
    [SerializeField] float furniture_Rotation;
    [SerializeField] float rotation_Speed;
    float _rotationValue = 0;

    private void Start()
    {
        furniture_Rotation = transform.rotation.eulerAngles.y;
        _rotationValue = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        UpdateRotation();
    }

    public void SetFurnitureRotation(string _side)
    {
        if (_side == "Left")
            furniture_Rotation -= 90;
        else if (_side == "Right")
            furniture_Rotation += 90;
        else
            Debug.Log("Wrong Rotation Input!!");
    }

    private void UpdateRotation()
    {
        _rotationValue = Mathf.MoveTowards(_rotationValue, furniture_Rotation, rotation_Speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, _rotationValue, 0);
    }
}
