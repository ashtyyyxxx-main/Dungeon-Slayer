using UnityEngine;

public class LookingAt : MonoBehaviour
{
    [SerializeField] private float lookingDistance;
    public GameObject LookingAtObj()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, lookingDistance))
        {
            if (hitInfo.collider != null)
            {
                return hitInfo.transform.gameObject;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
