using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDmg : MonoBehaviour, IHealth
{
    [SerializeField]
    private int startingHp = 100;

    [SerializeField]
    private float pTime;

    [SerializeField]
    private float pHits;

    private int curHp;
    public bool isPoisoned = false;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    

    // Start is called before the first frame update
    private void Start()
    {
        curHp = startingHp;
        pHits = 0;
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

        if (type != "Poison")
        {
            curHp -= amount;
        }
        else if (type == "Poison" && pHits < 5)
        {
            curHp -= amount;
            pHits++;
        }

        if(pHits >= 5)
        {
            isPoisoned = true;
            StartCoroutine(pTimer(pTime, amount));
        }

        OnHPPctChanged(CurrentHpPct);

        if (curHp <= 0)
        {
            OnDied();
        }
    }

    private IEnumerator pTimer(float timer, int dmg)
    {
        while (timer != 0)
        {
            yield return new WaitForSeconds(0.5f);
            curHp -= (int)(dmg * 0.3f);
        }
    }
}
