using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFTapToPlace : MonoBehaviour
{
    public GameObject m_prefabObject;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    public ARRaycastManager m_arRaycastManager;

    private void Awake()
    {
        m_arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //if a touch has not been detected
            //if(touch.phase != TouchPhase.Began)
            // {
            //     return; //end and do not run the rest of the code after this line
            // }

            if (m_arRaycastManager.Raycast(touch.position, s_hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_hits[0].pose;
                Instantiate(m_prefabObject, hitPose.position, hitPose.rotation);
            }
        }
    }

}
