using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SnapToItem : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public RectTransform ContentPanel;
    public RectTransform SampleListItem;
    public HorizontalLayoutGroup HLG;
    public TMP_Text NameLabel;
    public string[] ItemNames;
    private bool _isSnapped;
    public float SnapForce;
    public float MinScrollSpeed;
    public float ItemScaleSpeed;
    public float ItemScaleMax;
    public float ItemScaleMin;
    private float snapSpeed;
    void Update()
    {
        int currentItem = Mathf.RoundToInt(0 - ContentPanel.localPosition.x / (SampleListItem.rect.width + HLG.spacing));
        Debug.Log(currentItem);
        if (ScrollRect.velocity.magnitude < MinScrollSpeed && _isSnapped == false) {
            ScrollRect.velocity = Vector2.zero;
            snapSpeed += SnapForce * Time.deltaTime;
            ContentPanel.localPosition = new Vector3(Mathf.MoveTowards(ContentPanel.localPosition.x, 0 - (currentItem *
                                        (SampleListItem.rect.width + HLG.spacing)), snapSpeed) ,
                                        ContentPanel.localPosition.y, ContentPanel.localPosition.z);
            NameLabel.text = ItemNames[currentItem];
            if (ContentPanel.localPosition.x == 0 - (currentItem * (SampleListItem.rect.width + HLG.spacing))) {
                _isSnapped = true;
            }
            
        }
        if (ScrollRect.velocity.magnitude > MinScrollSpeed) {
            NameLabel.text = "";
            _isSnapped = false;
            snapSpeed = 0;
        }

        ContentPanel.GetChild(currentItem).GetComponent<RectTransform>().localScale =
            Vector3.one * Mathf.MoveTowards(ContentPanel.GetChild(currentItem).GetComponent<RectTransform>().localScale.x,
            ItemScaleMax, 
            Time.deltaTime * ItemScaleSpeed);;

        for (int i = 0; i < ContentPanel.childCount; i++) {
            if (i != currentItem) {
                ContentPanel.GetChild(i).GetComponent<RectTransform>().localScale =
                    Vector3.one * Mathf.MoveTowards(ContentPanel.GetChild(i).GetComponent<RectTransform>().localScale.x,
                    ItemScaleMin, 
                    Time.deltaTime * ItemScaleSpeed);
            }
        }
    }
}
