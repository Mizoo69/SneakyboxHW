using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddFurniture : MonoBehaviour
{
    public Button[] modelButtons; // array of buttons
    public List<GameObject> availableObjectModels;

    private ChangeColor changeColor;
    private GameObject selectedFurnitureModel; // selected furniture model
    private GameObject placedFurniture; // instantiated furniture model

    private bool isPlacingFurniture;

    private void Start()
    {
        foreach (var button in modelButtons)
        {
            string modelName = button.name;
            GameObject model = Resources.Load<GameObject>(modelName);

            if (model != null)
            {
                button.onClick.AddListener(() => SelectModel(model));
            }
        }

    }

    private void Update()
    {
        if (isPlacingFurniture && placedFurniture != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            worldPosition.y = placedFurniture.transform.position.y;
            placedFurniture.transform.position = worldPosition;

            if (Input.GetMouseButtonDown(0))
            {
                StopPlacingFurniture();
            }
        }
    }

    private void SelectModel(GameObject model)
    {
        selectedFurnitureModel = model;
        StartPlacingFurniture();
    }

    private void StartPlacingFurniture()
    {
        if (selectedFurnitureModel != null)
        {
            placedFurniture = Instantiate(selectedFurnitureModel);

            isPlacingFurniture = true;

            changeColor = placedFurniture.GetComponent<ChangeColor>();

            if (changeColor != null)
            {
                changeColor.redSlider = GameObject.Find("Red").GetComponent<Slider>();
                changeColor.greenSlider = GameObject.Find("Green").GetComponent<Slider>();
                changeColor.blueSlider = GameObject.Find("Blue").GetComponent<Slider>();
            }
        }
    }

    private void StopPlacingFurniture()
    {
        if (placedFurniture != null)
        {
            isPlacingFurniture = false;
            placedFurniture = null;
        }
    }
}
