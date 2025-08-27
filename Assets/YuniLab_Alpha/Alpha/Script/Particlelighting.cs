
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlelighting : MonoBehaviour
{
    public ParticleSystem biribiri;
    public GameObject player;//Unityエディターで参照を渡してください
    public Player ppp;
    public bool FastCheck=false;
    public float CoolTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("AM_sikaberu_run");

        biribiri = GetComponentInChildren<ParticleSystem>();
        ppp=Player.Instance.GetComponent<Player>();
    
    }

    // Update is called once per frame
    void Update()
    {
        CoolTime += Time.deltaTime;

        if (ppp.UseKey == false&&ppp.Maxshocktime< CoolTime)
        {
            Debug.Log("a");
            biribiri.Play();
            CoolTime=0.0f;  
        }

    }
}
