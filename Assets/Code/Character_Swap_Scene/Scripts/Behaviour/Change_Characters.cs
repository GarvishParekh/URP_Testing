using UnityEngine;

public class Change_Characters : MonoBehaviour
{
    public GameObject[] characters;
    public int indexToShow = 0;
    
    public void OnChangeCharacter_Next()
    {
        if (indexToShow >= characters.Length-1)
            indexToShow = 0;
        else
            indexToShow++;
        
        HideAllObjects();
        characters[indexToShow].gameObject.SetActive(true);
    }

    public void OnChangeCharacter_Pervious()
    {
        if (indexToShow <= 0)
            indexToShow = characters.Length - 1;
        else
            indexToShow--;

        HideAllObjects();
        characters[indexToShow].gameObject.SetActive(true);
    }

    private void HideAllObjects ()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }
    }

}
