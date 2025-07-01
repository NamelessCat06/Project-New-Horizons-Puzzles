using UnityEngine;

public class OrderCheckerScript : MonoBehaviour
{
    public ItemDrag[] correctOrder;
    public ItemSlot[] slots;

    // Update is called once per frame
    void Update()
    {
        bool isCorrect = true;
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (correctOrder[i] != slots[i].droppedItem)
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Win!");
        }
    }
}
