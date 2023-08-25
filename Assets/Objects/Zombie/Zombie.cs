using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : MonoBehaviour
{
    public float speed;                 // ���������
    private bool isMoving;              // ���������� ����������� ��������� �� ����� � ��������
    public LayerMask solidObjectsLayer; // ������� � ��������� ����� ������� ������ ������ 

    public GameObject player;
       

    //����� ���������� �������� ����� �������� ����
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ���������
        System.Random MoveRandom = new System.Random();
        var targetPos = player.transform.position; //������� ������� ����������� ������� �������

        if (!isMoving)
        {
            {
                if (IsWalkable(targetPos))          //IsWalkable ��������� ����� �� ����� ���������
                    StartCoroutine(Move(targetPos));
            }
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.4f, solidObjectsLayer) != null) //���� � ���������� ������� ���������� ������
        {                                                                       //�� ���� solidObjectLayer 
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
