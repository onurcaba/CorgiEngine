using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine {
    public class ElectricField : CharacterAbility
    {
        public float U;
        public GameObject testGameObject;
        public GameObject testElectricField;
        public Vector3 positionOfPlayer;
        public Vector3 positionOfElectricZone;
        public float passedDistance;
        public bool isInElctricField;
        public bool isLeftElectricField;
        public bool isRightElectricField;
        public Vector2 force;
        public float halfLength;
        public float needPower;
        public void initialize()
        {   halfLength = 1.9692725f;
            U = 60f;
            force = new Vector2(0,0);
            needPower = 9f;
    }
        public void Start()
        {
            initialize();
        }
        public void Update()
        {
            testGameObject = GameObject.FindGameObjectWithTag("Player");
            force = new Vector2(-testGameObject.GetComponent<test>().Q * U, 0);
            testElectricField.GetComponent<ForceZone>().AddedForce = force;
            positionOfPlayer = testGameObject.transform.position;
            positionOfElectricZone = testElectricField.transform.position;
            passedDistance = positionOfPlayer.x - positionOfElectricZone.x + halfLength;

            if (passedDistance >= 0 && passedDistance <= 2 * halfLength)
            {
                isInElctricField = true;
            }
            else
            {
                isInElctricField = false;
            }

            if (passedDistance < 0)
            {
                isLeftElectricField = true;
            }
            else
            {
                isLeftElectricField = false;
            }

            if (passedDistance > 2 * halfLength)
            {
                isRightElectricField = true;
            }
            else
            {
                isRightElectricField = false;
            }
        }
    }

}