using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscShooter : MonoBehaviour
{
    public GameObject CurrentDisc { get; set; }
    private float _interpolationPeriod = 3.0f;
    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
;    }

    // Update is called once per frame
    void Update()
    {

        _time += Time.deltaTime;
        if (_time >= _interpolationPeriod)
        {
            StartCoroutine(ShootDisc());
            _time = 0;
        }            
    }

    private IEnumerator ShootDisc()
    {
        for (int i = 0; i < 5; i++)
        {
            var randX = Random.Range(-70, -30);
            var randY = Random.Range(75, 100);
            this.transform.rotation = Quaternion.Euler(randX, randY, 0);
            var disc = Resources.Load<GameObject>("Disc");

            var obj = Instantiate(disc, this.transform);

            var rigidBody = obj.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.up * 100);

            yield return new WaitForSeconds(0.2f);
        }        
    }
}
