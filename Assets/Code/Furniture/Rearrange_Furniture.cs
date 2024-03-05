using UnityEngine;
using UnityEngine.UI;

public class Rearrange_Furniture : MonoBehaviour
{
    public static Rearrange_Furniture instance;
    
    public enum Furniture_Available
    {
        IS_AVAILABLE,
        NOT_AVAILABLE
    }

    public Furniture_Available furniture_Available;
    [Header(" [COMPONENT] ")]
    public Transform selected_Furniture;
    
    [Header(" [VALUES] ")]
    [SerializeField] private Vector3 selected_Furniture_Position;
    [SerializeField] private float furniture_Movement_Speed = 0;
        
    [Header(" [USER INTERFACE] ")]
    [SerializeField] private CanvasGroup rotationCanvasGroup;
    [SerializeField] private CanvasGroup sliderCanvasGroup;
    public Slider xSlider;
    public Slider zSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UI_Update();
    }

    private void LateUpdate()
    {
        if (selected_Furniture != null)
        {
            furniture_Available = Furniture_Available.IS_AVAILABLE;
            
            selected_Furniture_Position.x = xSlider.value;
            selected_Furniture_Position.z = zSlider.value;
            selected_Furniture.position = Vector3.MoveTowards(selected_Furniture.position, selected_Furniture_Position, furniture_Movement_Speed * Time.deltaTime);
        }
        else
        {
            furniture_Available = Furniture_Available.NOT_AVAILABLE;
        }
    }

    private void UI_Update()
    {
        if (furniture_Available == Furniture_Available.IS_AVAILABLE)
        {
            FadeInOutCanvasGroup(sliderCanvasGroup, 5, 1, true);
            FadeInOutCanvasGroup(rotationCanvasGroup, 1, 1, true);
        }
        else if (furniture_Available == Furniture_Available.NOT_AVAILABLE)
        {
            FadeInOutCanvasGroup(sliderCanvasGroup, 5, 0, false);
            FadeInOutCanvasGroup(rotationCanvasGroup, 1, 0, false);
        }
    }

    private void FadeInOutCanvasGroup(CanvasGroup _canvasGroup, float _fadingTime, float _alphaEndValue, bool _interaction)
    {
        _canvasGroup.alpha = Mathf.MoveTowards(sliderCanvasGroup.alpha, _alphaEndValue, _fadingTime * Time.deltaTime);
        _canvasGroup.interactable = _interaction;
    }
}
