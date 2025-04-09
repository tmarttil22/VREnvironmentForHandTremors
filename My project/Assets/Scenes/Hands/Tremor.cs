using UnityEngine;

public class Tremor : MonoBehaviour
{
    public float tremorAmplitude = 0.002f;
    public float tremorFrequency = 10.0f;
    public Vector3 tremorAxis = new Vector3(1f, 1f, 1f);

    private Vector3 initialLocalPosition;
    private float offset;

    void Start()
    {
        initialLocalPosition = transform.localPosition;
        offset = Random.Range(0f, 100f);
    }

    void Update()
    {
        initialLocalPosition = transform.localPosition;
        
        float tremor = Mathf.Sin((Time.time + offset) * tremorFrequency) * tremorAmplitude;
        Vector3 tremorOffset = new Vector3(
            tremor * tremorAxis.x,
            tremor * tremorAxis.y,
            tremor * tremorAxis.z
        );

        transform.localPosition = initialLocalPosition + tremorOffset;
    }
}