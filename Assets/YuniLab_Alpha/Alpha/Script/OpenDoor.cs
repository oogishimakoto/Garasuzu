using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private float rotate = 180f;  //扉の開くスピード
    public float rotateSpeed = 10.0f;//回転速度
    public float startrotate = 180f;  //扉の開くスピード
    public float MaxRotate = 10f;//回転の限界角度
    public string openObjName = "Door (1)";
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find(openObjName);
        rotate = startrotate;

    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    public void Open()
    {
        if (rotate > MaxRotate)
            rotate += rotateSpeed * Time.deltaTime;

        if (rotate > 360)
            rotate -= 360;

        door.transform.eulerAngles = new Vector3(0f, rotate, 0f);

    }
}
