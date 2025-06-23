using UnityEngine;

public class RightPosition : MonoBehaviour
{
    public string Answer;
    GameObject parent;

    bool Sunflower;
    bool Pansy;
    bool Rose;
    bool Daisy;
    bool MorningGlory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = gameObject;
        Sunflower = false;
        Pansy = false;
        Rose = false;
        Daisy = false;
        MorningGlory = false;
    }

    void Update()
    {
        if (Sunflower && Daisy && Rose && Pansy && MorningGlory)
        {
            Win();
        }
    }

    void OnTransformChildrenChanged()
    {
        if (parent.transform.childCount > 0)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.CompareTag(Answer))
                {
                    Debug.Log("That's the right answer");
                    if (Answer == "Sunflower")
                    {
                        Sunflower = true;
                        Debug.Log("Sunflower True");
                    }
                    else if (Answer == "Pansy")
                    {
                        Pansy = true;
                        Debug.Log("Pansy True");
                    }
                    else if (Answer == "Rose")
                    {
                        Rose = true;
                        Debug.Log("Rose True");
                    }
                    else if (Answer == "Daisy")
                    {
                        Daisy = true;
                        Debug.Log("Daisy True");
                    }
                    else if (Answer == "MorningGlory")
                    {
                        MorningGlory = true;
                        Debug.Log("Glory True");
                    }
                }
                else
                {
                    Debug.Log("Thats wrong");
                }
            }
        }
        else
        {
            Debug.Log("There is no child");
            if (Answer == "Sunflower")
            {
                Sunflower = false;
                Debug.Log("Sunflower false");
            }
            else if (Answer == "Pansy")
            {
                Pansy = false;
                Debug.Log("Pansy false");
            }
            else if (Answer == "Rose")
            {
                Rose = false;
                Debug.Log("Rose false");
            }
            else if (Answer == "Daisy")
            {
                Daisy = false;
                Debug.Log("Daisy false");
            }
            else if (Answer == "MorningGlory")
            {
                MorningGlory = false;
                Debug.Log("Glory false");
            }
        }
    }

    void Win()
    {
        Debug.Log("YOU WIN");
    }
}
