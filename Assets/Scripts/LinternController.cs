using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternController : MonoBehaviour
{
    [SerializeField] private GameObject[] cuteView = null;
    [SerializeField] private GameObject[] darkView = null;

    [SerializeField] private Animator animator = null;

    [SerializeField] private GameObject linternVisual = null;

    public Action<bool> onChangedView = null;

    private void Start()
    {
        TurnViewOn(true);
    }

    public void LinternUpdate()
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
        Vector3 dir = transform.up * 3;
        Vector3 pos = transform.position + dir;
        linternVisual.transform.position = pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.TakeDamage();
        }
    }

    private void TurnViewOn(bool isCuteView)
    {
        
        for (int i = 0; i < cuteView.Length; i++)
        {
            cuteView[i].SetActive(isCuteView);
        }
        for (int i = 0; i < darkView.Length; i++)
        {
            darkView[i].SetActive(!isCuteView);
        }
        animator.SetBool("IsCuteView", isCuteView);

        onChangedView?.Invoke(isCuteView);
    }
}
