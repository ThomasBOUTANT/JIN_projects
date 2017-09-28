using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        // "Scene1" is the name of the first scene we created.
        Application.LoadLevel("Scene1");
    }
}
