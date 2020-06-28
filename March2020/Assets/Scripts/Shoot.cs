using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject m_prefabFireball;
    public float m_shootForce;

    public Transform m_thisTransform;
    private void Start()
    {
        m_thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject fireball = Instantiate(m_prefabFireball, m_thisTransform.position, m_thisTransform.rotation);
            fireball.GetComponent<Rigidbody>().AddForce(m_thisTransform.forward * m_shootForce);
            Destroy(fireball, 5);
        }
    }
}
