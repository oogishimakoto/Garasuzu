using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCon : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Fire");
        }
    }
    InputAction TJump, TMove, TFire;
    Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        var pInput = GetComponent<PlayerInput>();
        var actionMap = pInput.currentActionMap;
        TMove = actionMap["Move"];
        TFire = actionMap["Fire"];
        TJump = actionMap["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = TMove.ReadValue<Vector2>();
        bool fire = TFire.triggered;
        bool jump = TJump.triggered;
        Debug.Log(string.Format("move:{0} + Look:{1} + Fire:{2}", move, fire, jump));

        if(move.x>=1.0f)
        {
            Debug.Log("走ってまーす！");
        }
        if(fire==true)
        {
            Debug.Log("ばきゅーん！");
        }
        if(jump==true) 
        {
            Debug.Log("ぴょーん！");
        }
    }
}
