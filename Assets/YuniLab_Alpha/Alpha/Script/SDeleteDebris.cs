using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDeleteDebris : MonoBehaviour
{
    public float timer = 5.0f;
    private void Start()
    {
        Destroy(gameObject, timer);
    }


}
