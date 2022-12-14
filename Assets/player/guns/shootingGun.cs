using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shootingGun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource shootingSound;

    //bullet force
    public float shootForce, upwardForce;

    //gun stats
    public float timeBetweenShooting, spread;
    public int magazineSize;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public Slider shootDelaySlider;
    float delayValue=0;
    float delayTime;

    //bools
    bool shooting, readyToShoot, reloading;
    GameObject destroyed;
    //reference
    public Camera pointCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake()
    {
        //magazine full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        shootDelaySlider.maxValue = timeBetweenShooting;
        delayTime = timeBetweenShooting/(timeBetweenShooting/0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

    }

    void FixedUpdate()
    {
        if(delayValue<=timeBetweenShooting)
        {
            delayValue+=delayTime;
            shootDelaySlider.value =delayValue;
        }
    }

    private void MyInput()
    {
     //check if allowed hold button   
     if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
     else shooting = Input.GetKeyDown(KeyCode.Mouse0);

    //shooting
    if(shooting && readyToShoot && bulletsLeft > 0)
    {
        //set bullets shots to 0
        bulletsShot = 0;
        delayValue=0;
        shootDelaySlider.value = delayValue;
        Shoot();
    }

    }

    private void Shoot()
    {
        shootingSound.Play();
        readyToShoot = false;

        //find the exact hit position using a raycast
        Ray ray = pointCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //check if ray hits
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
            targetPoint=hit.point;
        else   
            targetPoint = ray.GetPoint(75);

        //calculate direction of attackPoint to TargetPoint
        Vector3 directionWithoudSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x =  Random.Range(-spread, spread);
        float y =  Random.Range(-spread, spread);
        //calculate new direction with spreaD
        Vector3 directionWithSpread = directionWithoudSpread + new Vector3(x,y,0);
        
        //spawn bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);


        //rotate bullet to shoot direction

        currentBullet.transform.forward = directionWithSpread.normalized;

        //add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(pointCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsShot++;
        destroyed = currentBullet;
        Destroy(currentBullet, 3f);
        if(allowInvoke)
        {
            Invoke("resetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    public void destroyBullet()
    {
        Destroy(destroyed);
    }

    private void resetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    public void attackSpeedUpgrade(float subsDelay)
    {
        if(timeBetweenShooting >= 0.1f)
        {
            timeBetweenShooting -= subsDelay;
            shootDelaySlider.maxValue = timeBetweenShooting;
            delayTime = timeBetweenShooting/(timeBetweenShooting/0.02f);
        }

    }

}
