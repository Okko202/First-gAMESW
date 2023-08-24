using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ������ �� ������

    private void LateUpdate()
    {
        // ������ ����� ������� ������, �������� �� ������������ �������
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x+10;
        transform.position = newPosition;
    }
}
