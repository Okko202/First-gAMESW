using UnityEngine;

public class PatternGenerator : MonoBehaviour
{
    public GameObject[] patternPrefabs; // ������ �������� ���������
    public Transform player; // ������ �� ������
    public float generateDistance = 10f; // ���������, �� ������� ������������ ����� ��������
    public float deleteDistance = 20f; // ���������, �� ������� ��������� ������ ��������
    public float patternSpacing = 5f; // ���������� ����� ����������

    private Vector3 lastGeneratedPatternPosition;
    private int currentPatternIndex = 0;
    private float playerLastX;

    void Start()
    {
        lastGeneratedPatternPosition = Vector3.zero;
    }

    void Update()
    {
        float playerX = player.position.x;

        if (playerX > playerLastX)
        {
            GeneratePattern(new Vector3(playerX + generateDistance, 0f, 0f));
            DeleteOldPatterns(playerX - deleteDistance);
        }

        playerLastX = playerX;
    }

    float GetPatternWidth(GameObject pattern)
    {
        Collider2D collider = pattern.GetComponent<Collider2D>();
        if (collider)
        {
            return collider.bounds.size.x;
        }
        return 0f;
    }

    void GeneratePattern(Vector3 position)
    {
        Vector3 prefabPosition = position;
        float prefabWidth = GetPatternWidth(patternPrefabs[currentPatternIndex]);

        prefabPosition.x += prefabWidth / 2 + patternSpacing;

        GameObject newPattern = Instantiate(patternPrefabs[currentPatternIndex], prefabPosition, Quaternion.identity);

        lastGeneratedPatternPosition = prefabPosition;

        currentPatternIndex = (currentPatternIndex + 1) % patternPrefabs.Length;
    }

    void DeleteOldPatterns(float minX)
    {
        GameObject[] allPatterns = GameObject.FindGameObjectsWithTag("Pattern"); // ���������, ��� �������� ����� ��� "Pattern"
        foreach (var pattern in allPatterns)
        {
            if (pattern.transform.position.x < minX)
            {
                Destroy(pattern);
            }
        }
    }
}