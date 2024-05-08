using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUI : MonoBehaviour
{
    public GameObject CarClosedImage;
    public Image CarImage;
    public int CarId;
    public bool IsOpen;
    private void Update() {
        int openCarsNum = SaveSystem.GetNumberOfOpenCars();
        if (CarId > openCarsNum) {
            CarClosedImage.SetActive(true);
        }
        else {
            CarClosedImage.SetActive(false);
            IsOpen = true;
        }
    }    
}
