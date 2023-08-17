using System.CodeDom.Compiler;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Grid gridPrefab; // Префаб Grid'а для генерации
    public Transform player; // Ссылка на игрока
    public float generateDistance = 10f; // Дистанция, на которой генерируются новые Grid'ы
    public float deleteDistance = 20f; // Дистанция, на которой удаляются старые Grid'ы
    public float generate = 68f;

    private Transform lastGeneratedGrid;

    void Start()
    {
        lastGeneratedGrid = Instantiate(gridPrefab, transform.position, Quaternion.identity).transform;
    }

    void FixedUpdate()
    {
        float playerX = player.position.x;
        float lastGridX = lastGeneratedGrid.position.x;

        if (playerX > lastGridX - generateDistance)
        {
            GenerateGrid(playerX + generate); // Передаем позицию для создания нового Grid'а
        }

        if (lastGridX < playerX - deleteDistance)
        {
            Destroy(lastGeneratedGrid.gameObject);
        }
    }

    void GenerateGrid(float positionX)
    {
        lastGeneratedGrid = Instantiate(gridPrefab, new Vector3(positionX, lastGeneratedGrid.position.y, lastGeneratedGrid.position.z), Quaternion.identity).transform;
    }
}