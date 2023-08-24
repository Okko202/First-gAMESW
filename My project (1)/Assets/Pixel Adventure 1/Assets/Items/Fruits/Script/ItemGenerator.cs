using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ������ �������� ��������
    public Transform player; // ������ �� ������
    public float minDistanceBetweenItems = 5f; // ����������� ���������� ����� ������������ ���������
    public float maxDistanceBetweenItems = 10f; // ������������ ���������� ����� ������������ ���������
    public float yOffset = 1f; // ������ �� ��������� �� ���� ������
    public float deleteDistance = 20f; // ���������, �� ������� ��������� �������

    private float nextItemDistance; // ���������� �� �������� ���������� �������
    private Vector3 lastItemPosition; // ������� ���������� ���������� �������

    void Start()
    {
        lastItemPosition = GetStartPosition();
        CalculateNextItemDistance();
    }

    void Update()
    {
        float playerX = player.position.x;
        float lastItemX = lastItemPosition.x;

        if (playerX > lastItemX)
        {
            float distanceToNextItem = lastItemX + nextItemDistance - playerX;

            if (distanceToNextItem <= 0)
            {
                GenerateItem(playerX + nextItemDistance);
                CalculateNextItemDistance();
            }

            DeletePassedItems(playerX - deleteDistance);
        }
    }

    void GenerateItem(float positionX)
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject newItem = Instantiate(itemPrefabs[randomIndex], new Vector3(positionX, yOffset, 0f), Quaternion.identity);
        lastItemPosition = newItem.transform.position;
    }

    void CalculateNextItemDistance()
    {
        nextItemDistance = Random.Range(minDistanceBetweenItems, maxDistanceBetweenItems);
    }

    Vector3 GetStartPosition()
    {
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float xPosition = player.position.x + cameraWidth * 0.5f;
        return new Vector3(xPosition, yOffset, 0f);
    }

    void DeletePassedItems(float minX)
    {
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("Item"); // ���������, ��� ������� ����� ��� "Item"
        foreach (var item in allItems)
        {
            if (item.transform.position.x < minX)
            {
                Destroy(item); // ������� ������, ���� �� ��������� �� ��������� ��������
            }
        }
    }
}