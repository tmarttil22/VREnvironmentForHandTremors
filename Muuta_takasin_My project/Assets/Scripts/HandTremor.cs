using UnityEngine;

public class EssentialTremor : MonoBehaviour
{
    [Header("Tremor Settings")]
    public float tremorFrequency = 10f;
    public float tremorAmplitude = 0.002f;
    public bool affectRotation = false;
    public float rotationAmplitude = 0.5f;

    void LateUpdate()
    {
        float time = Time.time * tremorFrequency;

        Vector3 tremorOffset = new Vector3(
            Mathf.PerlinNoise(time, 0f) - 0.5f,
            Mathf.PerlinNoise(0f, time) - 0.5f,
            Mathf.PerlinNoise(time, time) - 0.5f
        ) * tremorAmplitude * 2f;

        transform.localPosition = tremorOffset;

        if (affectRotation)
        {
            Vector3 rotOffset = new Vector3(
                (Mathf.PerlinNoise(time + 1f, 0f) - 0.5f) * 2f,
                (Mathf.PerlinNoise(0f, time + 1f) - 0.5f) * 2f,
                (Mathf.PerlinNoise(time + 2f, time + 2f) - 0.5f) * 2f
            ) * rotationAmplitude;

            transform.localRotation = Quaternion.Euler(rotOffset);
        }
        else
        {
            transform.localRotation = Quaternion.identity;
        }
    }
}
