using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int numOfHitsHp = 5;

    [SerializeField]
    private float ITime = 5f;

    private int hitsLeft;
    private bool canDmg = true;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public float CurrentHPPct
    {
        get
        {
            return (float)hitsLeft / (float)numOfHitsHp;
        }
    }

    private void Start()
    {
        hitsLeft = numOfHitsHp;
    }

    public void TakeDamage(string type, int amount)
    {
        if(canDmg)
        {
            StartCoroutine(ITimer());

            hitsLeft--;

            OnHPPctChanged(CurrentHPPct);

            if(hitsLeft == 0)
            {
                OnDied();
            }
        }
    }

    private IEnumerator ITimer()
    {
        canDmg = false;
        yield return new WaitForSeconds(ITime);
        canDmg = true;
    }
}
