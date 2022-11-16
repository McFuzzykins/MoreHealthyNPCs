using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvulnerableNPC : MonoBehaviour, IHealth
{
    [SerializeField]
    private int startingHp = 100;

    [SerializeField]
    private int numOfIHits = 3;

    [SerializeField]
    private float ITime = 5f;

    private int curHp;

    private bool canDmg = false;

    private int hitsLeft;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
        curHp = startingHp;
        hitsLeft = numOfIHits;
        
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
        
        if(canDmg)
        {
            curHp -= amount;
            Debug.Log("Invulnerable HP: " + curHp);
        }
        else if (canDmg && type == "Poison") //heal if hit with poison
        {
            curHp += (int)(amount * 0.5);
        }

        if (hitsLeft == 0)
        {
            canDmg = true;
        }
        else if (hitsLeft > 0)
        {
            StartCoroutine(ITimer());
            hitsLeft--;
            Debug.Log("Hits Left: " + hitsLeft);
        }

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

    private IEnumerator ITimer()
    {
        canDmg = false;
        yield return new WaitForSeconds(ITime);
        canDmg = true;
    }
}
