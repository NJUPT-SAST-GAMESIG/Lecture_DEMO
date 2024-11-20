using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal enum ZombieState
{
    Move,
    Eat,
    Die,
    Pause
}

public class Zombie : MonoBehaviour
{
    /// <summary>
    /// 基本状态
    /// </summary>
    private ZombieState zombieState = ZombieState.Move;

    private Rigidbody2D rb;
    public float speed = 1.2f;
    private Animator _animator;

    /// <summary>
    /// 自身血量
    /// </summary>
    public int ZombieHp = 100;

    public int zombiecurrentHp;

    /// <summary>
    /// 攻击参数
    /// </summary>
    public int atkpower = 20;

    public float atkSpeed = 1.5f;
    private float atkTimer = 0;
    private Plant currentEatenPlant;


    public GameObject head;

    private bool HaveHead = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        zombiecurrentHp = ZombieHp;
    }

    private void Update()
    { 
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eat:
                EatUpdate();
                break;
            case ZombieState.Die:
                DieUpdate();
                break;
            default:
                break;
        }
    }

    private void MoveUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
    }

    private void EatUpdate()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer >= atkSpeed && currentEatenPlant != null)
        {
            currentEatenPlant.TakeDamage(atkpower);
            atkTimer = 0;
        }
    }

    private void DieUpdate()
    {
    }

    /// <summary>
    /// 攻击植物
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Plant plant=other.GetComponent<Plant>();
        if (plant!=null)
        {
            _animator.Play("Eat");
            TransitionToEat();
            currentEatenPlant = other.GetComponent<Plant>();
            StartCoroutine(EatPlant(plant));
        }

        

    }


    private IEnumerator EatPlant(Plant plant)
    {
        plant.TakeDamage(atkpower);
        yield return new WaitUntil((() => { return plant.isAlive == false; }));
        _animator.Play("Move");
        zombieState = ZombieState.Move;
    }
    
    

    private void TransitionToEat()
    {
        zombieState = ZombieState.Eat;
        atkTimer = 0;
    }

    public void TransitionToPause()
    {
        zombieState = ZombieState.Pause;
        _animator.enabled = false;
        // rb.bodyType = RigidbodyType2D.Static;
    }

    public void TakeDamage(int damage)
    {
        if (zombiecurrentHp <= 0) return;

        zombiecurrentHp -= damage;
        if (zombiecurrentHp <= 0)
        {
            zombiecurrentHp = -1;
            Die();
        }

        var Hppercent = zombiecurrentHp * 1f / ZombieHp;
        _animator.SetFloat("Hppercent", Hppercent);
        if (Hppercent < .5f && HaveHead)
        {
            HaveHead = false;
            var go = Instantiate(head, transform.position, Quaternion.identity);
            Destroy(go, 2f);
        }
    }

    public void Die()
    {
        if (zombieState == ZombieState.Die) return;
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        
        Destroy(gameObject, 2f);
    }
}