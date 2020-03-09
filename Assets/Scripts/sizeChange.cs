using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeChange : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    private Material _material;
    public Color _color;
	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().material;
        _material.EnableKeyword("_EMISSION");

    }
	
	// Update is called once per frame
	void Update () {
        if (_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._audioBandBuffer[_band] * _scaleMultiplier) + _startScale);
            /*
            Color emissioncolor = new Color(_color.r * AudioPeer._audioBandBuffer[_band], _color.g * AudioPeer._audioBandBuffer[_band], _color.b * AudioPeer._audioBandBuffer[_band], 1);
            _material.SetColor("_EmissionColor", emissioncolor);
            */
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._audioBand[_band] * _scaleMultiplier) + _startScale, (AudioPeer._audioBand[_band] * _scaleMultiplier) + _startScale, (AudioPeer._audioBand[_band] * _scaleMultiplier) + _startScale);
            /*
            Color emissioncolor = new Color(_color.r * AudioPeer._audioBand[_band], _color.g * AudioPeer._audioBand[_band], _color.b * AudioPeer._audioBand[_band], 1);
            _material.SetColor("_EmissionColor", emissioncolor);
            */
        }
    }
}
