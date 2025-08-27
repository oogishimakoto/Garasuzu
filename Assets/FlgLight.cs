using UnityEngine;
using System.Collections;

public class FlgLight : MonoBehaviour
{

    private Light myLight;
    public bool near;

    // Use this for initialization
    void Start()
    {
        near = false;
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && near)
        {
            myLight.enabled = !myLight.enabled;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "AM_speaker_walk")
    {
            myLight.enabled = !myLight.enabled;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        near = false;
    }
}