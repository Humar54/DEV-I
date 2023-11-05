
using UnityEngine;


public class Cours_18_Fireball_skill : MonoBehaviour
{
    [SerializeField] private Cours18_Fireball _fireballPrefab;
    [SerializeField] private float _coolDown = 5f;

    private float _timer;


    private void Update()
    {
        CheckToSendFireball();
        _timer += Time.deltaTime;
    }

    private void CheckToSendFireball()
    {
        if (_timer > _coolDown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Ray ray;
                RaycastHit hit;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Cours18_Enemy enemy = hit.collider.GetComponent<Cours18_Enemy>();

                    if (enemy != null)
                    {
                        transform.LookAt(enemy.transform.position);
                        SendFireball(enemy.transform);
                    }
                }
            }
        }
    }

    public float GetTimerRatio()
    {
        return _timer / _coolDown;
    }

    private void SendFireball(Transform target)
    {
        Cours18_Fireball newFireball = Instantiate(_fireballPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        newFireball.SetTarget(target);
        _timer = 0;
    }
}
