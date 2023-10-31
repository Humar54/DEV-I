using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cours18Move : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _stopingDistance = 0.1f;
    private Camera _camera;
    private Vector3 _targetPosition;
    private float _yOffset;

    // Start is called before the first frame update
    void Start()
    {
        _yOffset =transform.position.y;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray;
            RaycastHit hit;
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                _targetPosition = hit.point+new Vector3(0, _yOffset,0);
                transform.LookAt(_targetPosition);
            }
        }

        if((transform.position-_targetPosition).magnitude> _stopingDistance)
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;
            transform.position += direction * _movementSpeed * Time.deltaTime;
        }
    }
}
