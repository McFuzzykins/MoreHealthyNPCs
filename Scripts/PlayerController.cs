using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string dmgType;

    [SerializeField]
    private int dmg;

    [SerializeField]
    private int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        dmgType = "Normal";
        dmg = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "NPC")
        {
            collider.gameObject.GetComponent<IHealth>().TakeDamage(dmgType, dmg);
        }
    }
}
