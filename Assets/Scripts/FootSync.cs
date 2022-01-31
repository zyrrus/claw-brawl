using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class FootSync : MonoBehaviour
    {
        public bool isTurnA;

        public bool CanMoveA()
        {
            return isTurnA;
        }
    }
}
