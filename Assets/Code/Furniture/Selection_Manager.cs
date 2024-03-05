using UnityEngine;
using System.Collections.Generic;

public class Selection_Manager : MonoBehaviour
{
    public static Selection_Manager instance;

    public GameObject selectedFurniture;
    [SerializeField] private List<Select_Furniture> selectFurnitureList = new List<Select_Furniture>();

    private void Awake()
    {
        instance = this;
    }

    public void UnSelectAll()
    {
        foreach (var selectFurniture in selectFurnitureList)
        {
            selectFurniture.UnSelectFunction();
        }
    }

    public void OnRotateLeft ()
    {
        selectedFurniture.GetComponent<Furniture_Rotation>().SetFurnitureRotation("Left");
    }
    public void OnRotateRIght ()
    {
        selectedFurniture.GetComponent<Furniture_Rotation>().SetFurnitureRotation("Right");
    }
}
