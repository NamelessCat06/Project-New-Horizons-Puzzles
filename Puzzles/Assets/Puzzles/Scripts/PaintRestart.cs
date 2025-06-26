using UnityEngine;

public class PaintRestart : MonoBehaviour
{
    public GameObject startPos;
    public GameObject instantiateLocation;

    public void Restart()
    {
        GameObject.Destroy(instantiateLocation.transform.GetChild(0).gameObject);
        Instantiate(startPos, instantiateLocation.transform);
    }
}