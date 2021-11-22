using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnEnable()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity =Vector3.zero;
        rb.AddForce(new Vector3(0,0,1f)*50,ForceMode.VelocityChange);
        Invoke(nameof(DisableAfterSecond),1f);
    }

    void DisableAfterSecond()
    {
        ObjectPool.Instance.ReturnToPool("bullet", this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var ec = other.GetComponent<EnemyController>();
            ec.Die();
            EnemyManager.Instance.Kill();
            ObjectPool.Instance.ReturnToPool("bullet", this.gameObject);
        }
    }
}