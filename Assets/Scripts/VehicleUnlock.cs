using UnityEngine;
using UnityEngine.UI;

public class VehicleUnlock : MonoBehaviour
{
    public int totalMetalCollected = 0;

    public bool carUnlocked;
    public bool trainUnlocked;
    public bool shipUnlocked;
    public bool planeUnlocked;
    
    public Text targetText;
    public string newText = "NULL";


    void Update()   
    {
      if (totalMetalCollected >= 10)
        {
            carUnlocked = true;
        }
      if (totalMetalCollected >= 50)
        {
            trainUnlocked= true;
        }

      if(totalMetalCollected >= 200)
        {
            shipUnlocked= true;
        }

      if(totalMetalCollected >= 300)
        {
            planeUnlocked= true;
        }

        newText = totalMetalCollected.ToString();

        targetText.text = newText;
    }
}
