using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // —сылка на игрока

    private void LateUpdate()
    {
        // «адаем новую позицию камеры, сохран€€ ее вертикальную позицию
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x+10;
        transform.position = newPosition;
    }
}
