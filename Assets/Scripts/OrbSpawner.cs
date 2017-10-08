﻿using System.Collections.Generic;using UnityEngine;public class OrbSpawner : MonoBehaviour{	[SerializeField] Orb orb;	public static List<Orb> orbs = new List<Orb>(6);    private Animator anim;    private bool mAxisInUse = false;    void Awake()    {        anim = GetComponentInParent<Animator>();    }    void Update ()	{		if (Input.GetAxisRaw("Fire1") != 0)
        {
            if (!mAxisInUse)
            {
                anim.SetTrigger("Cast");

                Orb newOrb = Instantiate(orb, gameObject.transform);
                newOrb.transform.parent = null;

                orbs.Add(newOrb);
                if (orbs.Count > 5)
                {
                    Destroy(orbs[0].gameObject);
                    orbs.RemoveAt(0);
                }

                mAxisInUse = true;
            }
		}        if (Input.GetAxisRaw("Fire1") == 0)
        {
            mAxisInUse = false;
        }	}}