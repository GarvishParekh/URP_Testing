using UnityEngine;
using System.Collections;

public class Select_Furniture : MonoBehaviour
{
    Selection_Manager selection_Manager;
    Rearrange_Furniture rearrange_Furniture;

    public enum CroutineStatus
    {
        Idel,
        Running
    }
    public enum Status
    {
        SELECTED,
        UNSELECTED
    }
    public Status status;
    public CroutineStatus coroutineStatus;

    [SerializeField] private Transform selectedOutlineTransform;
    [SerializeField] private Vector3 selectedOutlineScale;
    [SerializeField] private Vector3 selectedOutlineFinalScale;

    private void Start()
    {
        selectedOutlineFinalScale = selectedOutlineTransform.localScale;
        selection_Manager = Selection_Manager.instance;
        rearrange_Furniture = Rearrange_Furniture.instance;
    }

    public void OnMouseDown()
    {
        Debug.Log("Selected");
        if (coroutineStatus == CroutineStatus.Running)
            return;

        if (status == Status.SELECTED)
        {
            SelectFunction();
        }
        else if (status == Status.UNSELECTED)
        {
            rearrange_Furniture.selected_Furniture = null;
            UnSelectFunction();
        }
    }
    private void SelectFunction()
    {
        StartCoroutine(nameof(ShowSelectedLine));
        status = Status.UNSELECTED;
    }

    public void UnSelectFunction()
    {
        selectedOutlineTransform.gameObject.SetActive(false);
        status = Status.SELECTED;
    }

    private IEnumerator ShowSelectedLine()
    {
        coroutineStatus = CroutineStatus.Running;
        rearrange_Furniture.selected_Furniture = transform;
        
        selection_Manager.UnSelectAll();
        selection_Manager.selectedFurniture = gameObject;
        SetSliderValue();
        
        selectedOutlineScale = Vector3.zero;
        selectedOutlineTransform.gameObject.SetActive(true);
        
        while (selectedOutlineScale != selectedOutlineFinalScale)
        {
            ChangeFurniturePosition();
            yield return null;
        }
        coroutineStatus = CroutineStatus.Idel;
    }

    private void ChangeFurniturePosition()
    {
        selectedOutlineScale = Vector3.MoveTowards(selectedOutlineScale, selectedOutlineFinalScale, 20 * Time.deltaTime);
        selectedOutlineTransform.localScale = selectedOutlineScale;
    }

    public void SetSliderValue()
    {
        rearrange_Furniture.xSlider.value = transform.position.x;
        rearrange_Furniture.zSlider.value = transform.position.z;
    }
}
