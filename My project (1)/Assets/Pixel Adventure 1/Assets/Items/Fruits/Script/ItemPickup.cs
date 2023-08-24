using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Animator animator; // Ссылка на аниматор объекта

    private bool pickedUp = false; // Флаг, чтобы предмет не был подобран несколько раз

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!pickedUp && other.CompareTag("Player"))
        {
            // Если объект с тегом "Player" входит в триггер, меняем параметр аниматора
            animator.SetBool("Collision", true);

            // Здесь можно добавить дополнительный код, например, звуковые эффекты, изменение очков и т.д.

            // Отмечаем, что предмет был подобран
            pickedUp = true;

            // Запускаем задержку для удаления объекта после анимации (подгоните значение под длительность анимации)
            float animationDuration = 0.6f;
            Destroy(gameObject, animationDuration);
        }
    }
}