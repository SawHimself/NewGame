using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;                 // Догадайся
    private bool isMoving;              // Переменная проверяющая находится ли игрок в движении
    private Vector2 input;              // Вектор считывающий нажатия клавиш
    public LayerMask solidObjectsLayer; // Уровень с объектами через которые нельзя ходить 
       

    //Метод вызывается единожды перед запуском игры
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Движение персонажа
       if(!isMoving)
        {
            //Считывание действий горизонтальных и вертикальных
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            
            if(input != Vector2.zero) //Если ввод не пустой, то есть мы что-то нажали
            {
                var targetPos = transform.position; //целевой позиции присваеваем текущую позицию
                targetPos.x += input.x;             //и прибавляем ввод 
                targetPos.y += input.y;

                if (IsWalkable(targetPos))          //IsWalkable проверяет может ли игрок двигаться
                    StartCoroutine(Move(targetPos));
            }
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.4f, solidObjectsLayer) != null) //Если в переданной позиции существует объект
        {                                                                       //из слоя solidObjectLayer 
            return false;
        }
        return true;
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
