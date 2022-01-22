using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject weaponModel;
        [SerializeField] private Vector3 originalPos;
        [SerializeField] private bool canAttack = true;
        [SerializeField] private bool isAttacking = false;
        [SerializeField] private bool weaponIsLeaving = false;
        [SerializeField] private float throwRange = 10;

        private void Awake()
        {
            originalPos = transform.position;
        }

        private void Update()
        {
            if (isAttacking)
            {
                if (Vector3.Distance(weaponModel.transform.position, originalPos) > throwRange)
                    weaponModel.transform.position += weaponModel.transform.forward * 1;
                isAttacking = false;
            }
        }

        public void HandleAttack()
        {
            Debug.Log("Attacking");
            isAttacking = true;
        }
    }
}