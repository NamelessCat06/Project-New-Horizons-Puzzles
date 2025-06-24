using UnityEngine;

public class PaintRestart : MonoBehaviour
{
    public GameObject startPos;
    public GameObject instantiateLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        GameObject.Destroy(instantiateLocation.transform.GetChild(0).gameObject);
        Instantiate(startPos, instantiateLocation.transform);
    }
}
