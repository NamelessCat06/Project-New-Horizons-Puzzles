using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class RightPosition : MonoBehaviour
{
    public string Answer;
    GameObject parent;
    public static float score = 0;
    public TextMeshProUGUI counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = gameObject;
    }

    void OnTransformChildrenChanged()
    {
        if (parent.transform.childCount > 0)
        {
            foreach (Transform child in parent.transform) {
                if (child.CompareTag(Answer))
                {
                    Debug.Log("That's the right answer");
                    score++;
                    counter.text = score.ToString();
                }
                else
                {
                    Debug.Log("Thats wrong");
                    if (score > 0)
                    {
                        score--;
                        counter.text = score.ToString();
                    }
                }
            }
        }
    }
}
