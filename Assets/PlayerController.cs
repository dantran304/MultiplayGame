﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public int runSpeed;
    public int rotationSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletSpeed;
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * runSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        //spawn bullet on the client
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
