using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class GetNegativeElectric : CharacterAbility
    {
        public GameObject testGameObject;

        public void Update()
        {
            testGameObject = GameObject.FindGameObjectWithTag("Player");
            testGameObject.GetComponent<test>().Q = 1.0f;
        }
    }
}
