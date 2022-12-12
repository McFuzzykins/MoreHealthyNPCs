using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    event Action<float> OnHPPctChanged;
    event Action OnDied;
    void TakeDamage(string type, int amount);
}


