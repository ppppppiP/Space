using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class ViewKilometers: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _kilometers;
    private float km = 0;

   
    private void Update()
    {
        km += RoadSpeed.Instance.Speed * Time.deltaTime;
        String kmText = Math.Round((km / 1000), 1).ToString().Replace(",", ".");
        
        _kilometers.text = kmText;
        
    }



}
