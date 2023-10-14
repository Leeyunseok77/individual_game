using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 몬스터가 죽었을 때 수행할 동작을 이곳에 구현합니다.
        // 예: 사운드 재생, 애니메이션 재생, 아이템 드랍 등
        // 여기에 필요한 추가 동작을 구현하세요.

        // 몬스터를 제거합니다.
        Destroy(gameObject);
    }
}
