using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public bool spreadShot = false;

	[Header("General")]
	public Transform gunBarrel;
	public ParticleSystem shotVFX;
	public AudioSource shotAudio;
	public float fireRate = .1f;
	public int spreadAmount = 20;

	[Header("Bullets")]
	public GameObject bulletPrefab;

	float timer;

	void Start()
	{

	}

	void Update()
	{
		timer += Time.deltaTime;

		if (Input.GetButton("Fire1") && timer >= fireRate)
		{
			Vector3 rotation = gunBarrel.rotation.eulerAngles;
			rotation.x = 0f;

			if (spreadShot)
				SpawnBulletSpread(rotation);
			else
				SpawnBullet(rotation);
			

			timer = 0f;

			if (shotVFX)
				shotVFX.Play();

			if (shotAudio)
				shotAudio.Play();
		}
	}

	void SpawnBullet(Vector3 rotation)
	{
		GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
		if (bullet != null)
		{
			bullet.transform.position = gunBarrel.position;
			bullet.transform.rotation = Quaternion.Euler(rotation);
			bullet.SetActive(true);
			StartCoroutine(DisAciveBullet(bullet));
		}
	}

	IEnumerator DisAciveBullet(GameObject bullet)
	{
		yield  return new WaitForSeconds(0.5f);
		bullet.SetActive(false);
	}

	void SpawnBulletSpread(Vector3 rotation)
	{
		int max = spreadAmount / 2;
		int min = -max;

		Vector3 tempRot = rotation;
		for (int x = min; x < max; x++)
		{
			tempRot.x = (rotation.x + 3 * x) % 360;

			for (int y = min; y < max; y++)
			{
				tempRot.y = (rotation.y + 3 * y) % 360;

				GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

				if (bullet != null)
				{
					bullet.transform.position = gunBarrel.position;
					bullet.transform.rotation = Quaternion.Euler(tempRot);
					bullet.SetActive(true);
					StartCoroutine(DisAciveBullet(bullet));
				}
			}
		}
	}

}

