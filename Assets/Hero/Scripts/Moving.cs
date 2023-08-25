using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;                 // ���������
    private bool isMoving;              // ���������� ����������� ��������� �� ����� � ��������
    private Vector2 input;              // ������ ����������� ������� ������
    public LayerMask solidObjectsLayer; // ������� � ��������� ����� ������� ������ ������ 
       

    //����� ���������� �������� ����� �������� ����
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ���������
       if(!isMoving)
        {
            //���������� �������� �������������� � ������������
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            
            if(input != Vector2.zero) //���� ���� �� ������, �� ���� �� ���-�� ������
            {
                var targetPos = transform.position; //������� ������� ����������� ������� �������
                targetPos.x += input.x;             //� ���������� ���� 
                targetPos.y += input.y;

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
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
