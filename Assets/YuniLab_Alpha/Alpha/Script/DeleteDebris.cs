using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDebris : MonoBehaviour
{
    [Header("������^�C�~���O�̂��")]
    public float deeees;
    private float timing;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (timing > deeees)
        {
            Destroy(this.gameObject);
        }
        if (tr.position.y <= -10.0f)
        {
            //Debug.Log("��������");
            Destroy(this.gameObject);
        }


    }
}
