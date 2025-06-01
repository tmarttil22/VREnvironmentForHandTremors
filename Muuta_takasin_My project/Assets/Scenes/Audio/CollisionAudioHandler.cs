using UnityEngine;

public class CollisionAudioHandler : MonoBehaviour
{
    int ignoreLayer1;
    int ignoreLayer2;
    AudioSource collisionAudio;
    
    void Start()
    {
        ignoreLayer1 = LayerMask.NameToLayer("LeftHandPhysics");
        ignoreLayer2 = LayerMask.NameToLayer("RightHandPhysics");
        collisionAudio = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != ignoreLayer1 && 
            collision.gameObject.layer != ignoreLayer2 &&
            !collisionAudio.isPlaying)
        {
            collisionAudio.Play();

        }
    }
}
