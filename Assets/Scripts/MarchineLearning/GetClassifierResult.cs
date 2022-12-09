using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetClassifierResult : MonoBehaviour
{
    ImageToEmotionClassifier _classifier = new ImageToEmotionClassifier();
    [SerializeField] private GameObject gameObject;
    [SerializeField] private TextMeshProUGUI MLResultText;


    private void Awake() 
    {
        _classifier = GameObject.Find("ImageToEmotionclassifier").GetComponent<ImageToEmotionClassifier>();
    }
    
    
    public void AnalysisButton()
    {
        MLResultText.text += _classifier.result;
    }
    
    
    
    
}
