using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private LookingAt m_LookingAt;
    [SerializeField] private GameObject pressToInteractText;

    private void Awake()
    {
        m_LookingAt = FindAnyObjectByType<LookingAt>();
    }
    private void Update()
    {
        if (m_LookingAt.LookingAtObj() != null)
        {
            if (m_LookingAt.LookingAtObj().gameObject.TryGetComponent(out IInteractable interactable))
            {
                pressToInteractText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    pressToInteractText.SetActive(false);
                }
            }
        }

        var obj = m_LookingAt.LookingAtObj();
        if (obj == null || obj.TryGetComponent(out IInteractable interactable1) == false)
        {
            pressToInteractText.SetActive(false);
        }
    }
}
