using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem deathPartSystem;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<IHealth>().OnDied += HandleNPCDied;
    }

    private void HandleNPCDied()
    {
        var deathPart = Instantiate(deathPartSystem, transform.position, transform.rotation);
        Destroy(deathPart, 4f);
    }
}
