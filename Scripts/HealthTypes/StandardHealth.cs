using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int startingHp = 100;

    private int curHp;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
        curHp = startingHp;
    }

    private float CurrentHpPct
    {
        get
        {
            return (float)curHp / (float)startingHp;
        }
    }

    public void TakeDamage(string type, int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid Damage Amount Specified: " + amount);
        }

        curHp -= amount;
        Debug.Log("Damage Received");
        Debug.Log(curHp);

        OnHPPctChanged(CurrentHpPct);

        if (curHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
