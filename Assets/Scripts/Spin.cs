using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 speed = new Vector3(20, 41, 0);

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}