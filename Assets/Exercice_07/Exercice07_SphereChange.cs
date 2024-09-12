
using UnityEngine;

public class Exercice07_SphereChange : MonoBehaviour
{
    [SerializeField] private Ex07_Move _whiteSphere;
    [SerializeField] private Ex07_Move _blackSphere;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _whiteSphere.enabled = true;
            _blackSphere.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _whiteSphere.enabled = false;
            _blackSphere.enabled = true;
        }
    }
}
