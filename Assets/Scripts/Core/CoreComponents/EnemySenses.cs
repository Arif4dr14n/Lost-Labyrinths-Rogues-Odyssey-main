using System;
using System.Collections.Generic;
using UnityEngine;

public enum SensorType
{
    Box,
    Circle
}

[Serializable]
public class SensorData
{
    public string sensorName;
    public SensorType sensorType = SensorType.Box;
    public Vector2 positionOffset;
    public Vector2 size = new Vector2(0.3f, 0.3f);
    public float radius = 0.15f;
    public LayerMask detectionLayer;
}

public class EnemySenses : CoreComponent
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    [SerializeField] private List<SensorData> sensors = new List<SensorData>();

    private bool CheckSensor(SensorData sensor)
    {
        Vector2 flippedOffset = new Vector2(sensor.positionOffset.x * Movement.FacingDirection, sensor.positionOffset.y);
        Vector2 worldPosition = (Vector2)transform.position + flippedOffset;
        bool detected = false;

        if (sensor.sensorType == SensorType.Box)
        {
            detected = Physics2D.OverlapBox(worldPosition, sensor.size, 0, sensor.detectionLayer);
        }
        else if (sensor.sensorType == SensorType.Circle)
        {
            detected = Physics2D.OverlapCircle(worldPosition, sensor.radius, sensor.detectionLayer);
        }

        Debug.Log($"Sensor {sensor.sensorName} ({sensor.sensorType}) checking at position {worldPosition}, detected: {detected}");
        return detected;
    }

    public bool IsSensorTriggered(string sensorName)
    {
        SensorData sensor = sensors.Find(s => s.sensorName == sensorName);
        return sensor != null && CheckSensor(sensor);
    }

    private void OnDrawGizmosSelected()
    {
        if (sensors == null || sensors.Count == 0) return;

        foreach (var sensor in sensors)
        {
            Vector2 flippedOffset = new Vector2(sensor.positionOffset.x * (Application.isPlaying ? Movement.FacingDirection : 1), sensor.positionOffset.y);
            Vector2 worldPosition = (Vector2)transform.position + flippedOffset;

            Gizmos.color = sensor.detectionLayer == LayerMask.GetMask("Player") ? Color.red : Color.blue;

            if (sensor.sensorType == SensorType.Box)
            {
                Gizmos.DrawWireCube(worldPosition, sensor.size);
            }
            else if (sensor.sensorType == SensorType.Circle)
            {
                Gizmos.DrawWireSphere(worldPosition, sensor.radius);
            }
        }
    }
}

