using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class IceDisappear : CharacterAbility
    {
        public GameObject testGameObject;
        public GameObject ice1;
        public GameObject collider1;
        public GameObject ice2;
        public GameObject collider2;
        public void Update()
        {
            testGameObject = GameObject.FindGameObjectWithTag("Player");

            if (collider1.active != true)
            {
                testGameObject.GetComponent<test>().temprature = 2f;
            }
            if(collider2.active != true)
            {
                testGameObject.GetComponent<test>().temprature = 4f;
            }

        }
    }
}
