using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public GameObject m_touchingObject; //what we are touching
    public GameObject m_heldObject; //what we are holding

    //OnTrigger Stay, Exit, Enter needs object that the script is on the a collider with trigger zone at least 1 collider with trigger zone
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {         
            m_touchingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_touchingObject == other.gameObject)
        {
            m_touchingObject = null;
        }
    }

    // OnCollisionEnter needs both objects to have rigidboddies and regular colliders. 1 each
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Rigidbody>())
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (m_touchingObject) //m_touchingObject != null
            {
                Grab();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (m_heldObject)
            {
                Release();
            }
        }
    }

    void Grab()
    {
        // if item is heavier than 10 don't pick up
        if (m_touchingObject.GetComponent<Rigidbody>().mass > 10)
        { 
            return;
        }

        m_heldObject = m_touchingObject;
        m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
        m_heldObject.transform.SetParent(transform);
    }

    void Release()
    {
        m_heldObject.transform.SetParent(null);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_heldObject = null;
    }

}