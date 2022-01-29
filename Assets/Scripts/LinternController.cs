using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternController : MonoBehaviour
{
    [SerializeField] private GameObject cuteView = null;
    [SerializeField] private GameObject darkView = null;

    [SerializeField] private Animator animator = null;

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
        cuteView.SetActive(isCuteView);
        darkView.SetActive(!isCuteView);
        animator.SetBool("IsCuteView", isCuteView);

        onChangedView?.Invoke(isCuteView);
    }
}
