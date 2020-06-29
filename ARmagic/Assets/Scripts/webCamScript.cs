using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour
{
    public GameObject webCameraPlane;


    public GameObject m_prefabFireball;
    public Button m_castFireButton;
    public float m_shootForce;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;

        m_castFireButton.onClick.AddListener(OnButtonDown);

        WebCamTexture webCameraTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();
    }

    void OnButtonDown()
    {

        //GameObject fireBall = Instantiate(Resources.Load("fireBall", typeof(GameObject))) as GameObject;
        //Rigidbody rb = fireBall.GetComponent<Rigidbody>();
        //fireBall.transform.rotation = Camera.main.transform.rotation;
        //fireBall.transform.position = Camera.main.transform.position;
        //rb.AddForce(Camera.main.transform.forward * 500f);
        //Destroy(fireBall, 3);

        GameObject fireball = Instantiate(m_prefabFireball, Camera.main.transform.position, Camera.main.transform.rotation);
        fireball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * m_shootForce);
        Destroy(fireball, 5);

       // GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;
    }
}
