using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;

    void Start()
    {
        renderer.enabled = false;
    }
}
