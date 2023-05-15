using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeightText : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TMP_Text textMesh;
    public string yValue;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void FixedUpdate()
    {
        textMesh.text = Convert.ToString((int)player.position.y);
        yValue = textMesh.text;
    }
}
