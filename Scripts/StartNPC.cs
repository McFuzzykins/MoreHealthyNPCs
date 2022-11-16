using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StartNPC : MonoBehaviour
{
    [SerializeField]
    private int _startingHp = 100;

    [SerializeField]
    private UnityEngine.UI.Slider _hpBarSlider;

    [SerializeField]
    private ParticleSystem deathParticlePrefab;

    private int _curHp;

    private void Start()
    {
        _curHp = _startingHp;
    }

    internal void TameDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);
        }

        _curHp -= amount;

        UpdateUI();

        if (_curHp <= 0)
        {
            Die();
        }
    }

    private void UpdateUI()
    {
        var curHpPct = (float)_curHp / (float)_startingHp;

        _hpBarSlider.value = curHpPct;
    }

    private void Die()
    {
        PlayDeathParticle();
        GameObject.Destroy(this.gameObject);
    }

    private void PlayDeathParticle()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        Destroy(deathParticle, 4f); 
    }
}
