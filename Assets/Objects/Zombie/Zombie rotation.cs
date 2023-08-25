using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test
public class Zombierotation : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Vector2 direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        transform.right = direction;
    }
}
