using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Animator animator; // ������ �� �������� �������

    private bool pickedUp = false; // ����, ����� ������� �� ��� �������� ��������� ���

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!pickedUp && other.CompareTag("Player"))
        {
            // ���� ������ � ����� "Player" ������ � �������, ������ �������� ���������
            animator.SetBool("Collision", true);

            // ����� ����� �������� �������������� ���, ��������, �������� �������, ��������� ����� � �.�.

            // ��������, ��� ������� ��� ��������
            pickedUp = true;

            // ��������� �������� ��� �������� ������� ����� �������� (��������� �������� ��� ������������ ��������)
            float animationDuration = 0.6f;
            Destroy(gameObject, animationDuration);
        }
    }
}