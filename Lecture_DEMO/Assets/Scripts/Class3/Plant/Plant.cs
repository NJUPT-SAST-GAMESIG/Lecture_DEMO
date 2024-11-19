using UnityEngine;

public class Plant : MonoBehaviour
{
    public string plantName; // 植物名称
    public int health; // 生命值
    public int attackDamage; // 攻击伤害
    public float attackCooldown; // 攻击冷却时间
    public float attackRange; // 攻击范围
    public bool isAlive = true; // 植物是否存活

    private float attackTimer; // 攻击冷却计时器


    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isAlive = false;

        Animator animator = gameObject.GetComponent<Animator>();
        if (animator == null )
            animator=gameObject.AddComponent<Animator>();
        animator.runtimeAnimatorController = null;
    }


    protected virtual void FixedUpdate()
    {
        if (!isAlive) return;

        // 更新攻击冷却时间
        if (attackTimer < attackCooldown)
        {
            attackTimer += Time.fixedDeltaTime;
        }
        else
        {
            // 攻击冷却结束，可以执行攻击
            Attack();
            attackTimer = 0f; 
        }
    }

    // 植物攻击行为（可以根据需要重写）
    protected virtual void Attack()
    {
        // 这里可以放置攻击逻辑，例如检查攻击范围内的僵尸并造成伤害
        Debug.Log($"{plantName} attacks with {attackDamage} damage.");
    }
}