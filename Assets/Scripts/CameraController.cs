using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float offsetX;

    [SerializeField]
    private float offsetY;

    private void Update()
    {
        var playerPosition = player.position;
        transform.position = new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, transform.position.z);
    }
}