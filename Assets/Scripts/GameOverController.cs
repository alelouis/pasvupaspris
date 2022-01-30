using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public InputAction restart;

    // Start is called before the first frame update
    void Start()
    {
        restart.performed += Restart;
        restart.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Restart(InputAction.CallbackContext context) 
    {
        SceneManager.LoadScene("PatrolScene");
    }

}
