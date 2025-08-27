using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCursle : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("このシーンにあるButtonを入れる")]
    [SerializeField]
    GameObject[] UIButton;
    private Button[] button;

    void Start()
    {
        for(int i=0;i<UIButton.Length;i++) 
        {
            button[i]=GetComponent<Button>();
            if (button[i]==null)
            {
                Debug.LogError("ボタンがないお");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {

        }
    }
}
