using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakableWallUI : MonoBehaviour
{
    [SerializeField] private Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ �ڵ带 ���⿡ �ۼ��� �� �ֽ��ϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        // �� �����Ӹ��� ������Ʈ �ڵ带 �ۼ��� �� �ֽ��ϴ�.
    }

    // ���� ü���� ������Ʈ�ϴ� �޼���
    public void UpdateWallHealth(float currentHealth, float maxHealth)
    {
        if (hpBar != null)
        {
            // ���� ü���� �ִ� ü�¿� ���� ������ �����Ͽ� Slider�� ������Ʈ
            hpBar.value = currentHealth / maxHealth;
        }
    }
}