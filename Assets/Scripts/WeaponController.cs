using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject weaponModel;
        private bool canAttack;

        public void HandleAttack()
        {
            Debug.Log("Attacking");
        }
    }
}
