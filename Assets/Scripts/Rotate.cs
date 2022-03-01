using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float sawRotateSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0, 0, 360 * sawRotateSpeed * Time.deltaTime);
    }
}