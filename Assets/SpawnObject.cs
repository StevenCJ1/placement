using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject sampleObject;

    public void AddObject()
    {
        Instantiate(sampleObject, Vector3.zero, Quaternion.identity);
    }

}
