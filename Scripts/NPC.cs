using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    internal void TakeDamage(string type, int amount)
    {
        GetComponent<IHealth>().TakeDamage(type, amount);
    }
}
