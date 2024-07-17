using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Цель, за которой будет следовать камера (персонаж)
    public Vector3 offset = new Vector3(0, 5, -10); // Отступ камеры относительно цели
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры

    void LateUpdate()
    {
        // Позиция цели с учетом отступа
        Vector3 desiredPosition = target.position + offset;

        // Плавное перемещение камеры к целевой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Поворот камеры для смотрения на цель
        transform.LookAt(target);
    }
}
