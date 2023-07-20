using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.25f;
    private float segmentLength = 35;
    private float lineWidth = 0.1f; // Fixed the data type here

    // Parameters for the swinging motion
    public float swingFrequency = 1f; // Adjust this value to control the swing speed
    public float swingAmplitude = 0.1f; // Adjust this value to control the swing amplitude

    // Start is called before the first frame update
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = this.transform.position; // Start the rope from the object's position

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SimulateRopeSwing();
        DrawRope();
    }

    private void SimulateRopeSwing()
    {
        float time = Time.time;

        // Simulate the swinging motion using a sine wave
        for (int i = 0; i < this.segmentLength; i++)
        {
            float offset = Mathf.Sin(time * swingFrequency + i) * swingAmplitude;
            this.ropeSegments[i].posNow.y = this.ropeSegments[i].posOriginal.y + offset;
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions); // Fixed the method name here
    }
}

public class RopeSegment
{
    public Vector3 posNow;
    public Vector3 posOriginal;

    public RopeSegment(Vector3 pos)
    {
        this.posNow = pos;
        this.posOriginal = pos;
    }
}

