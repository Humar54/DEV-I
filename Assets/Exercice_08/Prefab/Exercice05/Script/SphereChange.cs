using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChange : MonoBehaviour
{
    [SerializeField] private Ex05_Move _whiteSphere;
    [SerializeField] private Ex05_Move _blackSphere;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _whiteSphere.enabled = false;
            _blackSphere.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _whiteSphere.enabled = true;
            _blackSphere.enabled = false;
        }
    }
}
