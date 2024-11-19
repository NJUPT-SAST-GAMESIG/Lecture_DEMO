using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class peashooter : Plant
{
    private GameObject peaBullet;

    private void Start()
    {
        attackCooldown = 0.7f;
        peaBullet = Resources.Load<GameObject>("BulletPrefab/PeaBullet");
    }

    protected override void Attack()
    {
        base.Attack();
        if (peaBullet != null)
        {
            //Debug.Log(1);
            Vector3 trans =new Vector3(transform.position.x,transform.position.y+0.2f) ;
            
            GameObject pb= Instantiate(peaBullet,trans, Quaternion.identity);
            pb.transform.SetParent(transform.parent);
            pb.transform.SetSiblingIndex(1);
        }
        
    }
}