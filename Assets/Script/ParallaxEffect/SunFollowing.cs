using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _player;
    private Vector3 _tempPosition;
    private Vector3 _defaultPosition;

    private const string PLAYER = "Player";

    private void Start() {
        _player = GameObject.FindWithTag(PLAYER).transform;
        _tempPosition = transform.position;
        this._defaultPosition = _tempPosition;

    }
    private void LateUpdate() {
        _tempPosition.x = MakeDelayX(99);

        transform.position = _tempPosition;
    }
    
    private float MakeDelayX(int percentSmooth) {
        var player = _player.position.x;
        var tempPositionY = _tempPosition.x;

        var distance = Math.Abs(player - tempPositionY);
        var calculatedDistance = distance / 100 * percentSmooth;
        var step = player > tempPositionY
            ? tempPositionY + calculatedDistance
            : tempPositionY - calculatedDistance;
        return _defaultPosition.x - _tempPosition.x + step;
    }
}
