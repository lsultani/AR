using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFTapToMove : MonoBehaviour
{
    public GameObject m_prefabObject;

    private Transform m_placedTransform;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    public ARRaycastManager m_arRaycastManager;

    private void Awake()
    {
        m_arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (m_arRaycastManager.Raycast(touch.position, s_hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_hits[0].pose;

                if (m_placedTransform == null)
                {
                    m_placedTransform = Instantiate(m_prefabObject, hitPose.position, hitPose.rotation).transform;
                }
                else
                {
                    m_placedTransform.position = hitPose.position;
                }
            }
        }
    }
}
