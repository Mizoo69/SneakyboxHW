using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private Renderer objectRenderer;
    private Material objectMaterial;
    private Color currentColor;

    private void Start()
    {
        objectRenderer = GetComponentInChildren<Renderer>();
        objectMaterial = objectRenderer.material;
        currentColor = objectMaterial.color;

        redSlider.value = currentColor.r * 255;
        greenSlider.value = currentColor.g * 255;
        blueSlider.value = currentColor.b * 255;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(2))
                {
                    currentColor = new Color(
                        redSlider.value / 255f,
                        greenSlider.value / 255f,
                        blueSlider.value / 255f
                    );

                    objectMaterial.color = currentColor;
                }
            }
        }
    }

    public void OnColorChanged()
    {
        currentColor = new Color(
            redSlider.value / 255f,
            greenSlider.value / 255f,
            blueSlider.value / 255f
        );

        objectMaterial.color = currentColor;
    }
}
