using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
