using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : MonoBehaviour
{
    public float speed;                 // Догадайся
    private bool isMoving;              // Переменная проверяющая находится ли игрок в движении
    public LayerMask solidObjectsLayer; // Уровень с объектами через которые нельзя ходить 

    public GameObject player;
       

    //Метод вызывается единожды перед запуском игры
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Движение персонажа
        System.Random MoveRandom = new System.Random();
        var targetPos = player.transform.position; //целевой позиции присваеваем текущую позицию

        if (!isMoving)
        {
            {
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
            targetPos = player.transform.position;
            Vector3 Step = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (IsWalkable(Step))
                transform.position = Step;
            else
                Console.WriteLine("test_stop");
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
