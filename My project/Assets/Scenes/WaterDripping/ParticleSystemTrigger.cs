using UnityEngine;

public class ParticleSystemTrigger : MonoBehaviour
{
    public GameObject particleSystemObject;
    private ParticleSystem waterParticles;
    public float triggerDegree = 20.0f;
    private float degrees;
    private bool isPlaying;
    WaterController waterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterParticles = particleSystemObject.GetComponent<ParticleSystem>();
        waterParticles.Stop();
        isPlaying = false;

        if (gameObject.tag == "Mug") {
            waterController = gameObject.GetComponent<WaterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        particleSystemObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

        degrees = Vector3.Angle(Vector3.up, transform.up);

        if (gameObject.tag == "Mug" && waterController.isEmpty()) {
            waterParticles.Stop();
            isPlaying = false;
        
        } else if (degrees > triggerDegree) {
            if (!isPlaying) {
                waterParticles.Play();
                isPlaying = true;
            }
        } else {
            if (isPlaying) {
                waterParticles.Stop();
                isPlaying = false;
            }
        }

        RaycastHit hit;
        Ray ray = new Ray(particleSystemObject.transform.position, Vector3.down);
        if (isPlaying && Physics.Raycast(ray, out hit, 5)) {
            if(hit.collider.tag == "Mug") {
                WaterController waterController = hit.collider.GetComponent<WaterController>();
                waterController.Fill();
            }
        }

        if (gameObject.tag == "Mug" && isPlaying) {
            WaterController waterController = gameObject.GetComponent<WaterController>();
            waterController.Empty();
        }
    }

    public float getDegrees() {
        return degrees;
    }

    bool GetIsPlaying() {
        return isPlaying;
    }
}
