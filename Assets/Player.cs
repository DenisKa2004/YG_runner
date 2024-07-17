using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float moveSpeed = 10f;
    private Animator animator;
    private CharacterController characterController;

    void Start()
    {
        gameObject.transform.position = new Vector3(0, 6.905f, -9.17f);
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Вперед движение персонажа
        Vector3 forwardMove = transform.forward * runSpeed * Time.deltaTime;

        // Управление влево и вправо при зажатой левой кнопке мыши
        Vector3 horizontalMove = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            horizontalMove = transform.right * horizontalInput * moveSpeed * Time.deltaTime;
        }

        // Объединяем движение
        Vector3 move = forwardMove + horizontalMove;
        characterController.Move(move);

        // Обновляем высоту персонажа для сохранения постоянного уровня
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x, 6.905f, currentPosition.z);

        // Определяем состояние персонажа и устанавливаем анимации
        if (Input.GetMouseButton(0)) // Зажата левая кнопка мыши
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRun", false);
        }
    }
}
