using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitGame : MonoBehaviour
{
    public InputAction exitAction;
    // Start is called before the first frame update
    void Start()
    {
        exitAction.performed += Exit;
        exitAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy() {
        exitAction.Disable();
        exitAction.performed -= Exit;
    }

    void Exit(InputAction.CallbackContext context) 
    {
        Application.Quit();
    }
}
