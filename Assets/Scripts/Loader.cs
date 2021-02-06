using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject controller;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            Instantiate(controller);
        }
    }

}
