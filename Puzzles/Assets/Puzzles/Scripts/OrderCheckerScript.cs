using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderCheckerScript : MonoBehaviour
{
    public ItemDrag[] correctOrder;
    public ItemSlot[] slots;
    public string SceneName;
    public AudioSource correctAnswer;

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
            correctAnswer.Play();
            SceneManager.LoadScene(SceneName);
        }
    }
}
