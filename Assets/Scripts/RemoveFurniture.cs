using UnityEngine;

public class RemoveFurniture : MonoBehaviour
{
    private bool isEnabled;

    private void Start()
    {
        isEnabled = false;
    }

    private void Update()
    {
        if (!isEnabled)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Model"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    public void EnableScript()
    {
        isEnabled = true;
    }

    public void DisableScript()
    {
        isEnabled = false;
    }
}
