using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternController : MonoBehaviour
{
    [SerializeField] private GameObject cuteView = null;
    [SerializeField] private GameObject darkView = null;

    public Action<bool> onChangedView = null;


    private void Start()
    {
        TurnViewOn(true);
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 directonToLook = mouseWorldPosition - transform.position;
        transform.up = directonToLook;

        if (Input.GetMouseButtonDown(0))
        {
            TurnViewOn(true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            TurnViewOn(false);
        }
    }

    private void TurnViewOn(bool isCuteView)
    {
        cuteView.SetActive(isCuteView);
        darkView.SetActive(!isCuteView);

        onChangedView?.Invoke(isCuteView);
    }
}
