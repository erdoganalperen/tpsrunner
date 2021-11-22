using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    private void OnEnable()
    {
        pointA = pointB = transform.position;
 
        pointA.x = EnemyManager.Instance.groundSizeX / -2;
        pointB.x = EnemyManager.Instance.groundSizeX / 2;
        
        target = pointA;
        Invoke(nameof(DisableAfterSecond),10f);
    }

    void DisableAfterSecond()
    {
        ObjectPool.Instance.ReturnToPool("enemy", this.gameObject);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 8);
        if (Vector3.Distance(transform.position, target) < .1f)
        {
            SwitchTarget();
        }
    }

    public void Die()
    {
        ObjectPool.Instance.ReturnToPool("enemy", this.gameObject);
    }
    void SwitchTarget()
    {
        if (target.x < 0)
        {
            target = pointB;
        }
        else
        {
            target = pointA;
        }
    }
}