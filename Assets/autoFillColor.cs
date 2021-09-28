using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoFillColor : MonoBehaviour
{
    [SerializeField] Color disabledColor;
    [SerializeField] Color firstColor;
    [SerializeField] Color awakeColor;
    [SerializeField] Color disabledColorRim;
    [SerializeField] Color firstColorRim;
    [SerializeField] Color awakeColorRim;
    private Renderer _renderer;
    private Renderer _renderer2;
    private MaterialPropertyBlock _propBlock;
    private MaterialPropertyBlock _propBlock2;
    // Start is called before the first frame update
    void Start()
    {
        _propBlock = new MaterialPropertyBlock();
        _propBlock2 = new MaterialPropertyBlock();
        _propBlock2.Clear();
        _renderer = GetComponent<Renderer>();
        _renderer2 = GetComponent<Renderer>();
        _propBlock.SetColor("_RimColor", awakeColorRim);
        _propBlock2.SetColor("_Color", awakeColor);
        _renderer.SetPropertyBlock(_propBlock);
        _renderer2.SetPropertyBlock(_propBlock2);
    }

   
    public void FirstColor()
    {
        _propBlock.SetColor("_RimColor",firstColorRim);
        
        
        _renderer.SetPropertyBlock(_propBlock);

       
    }
    public void DisabledColor()
    {
        _propBlock.SetColor("_RimColor", disabledColorRim);
        
        
        _renderer.SetPropertyBlock(_propBlock);
       
    }
    public void EnabledColor()
    {
        _propBlock.SetColor("_RimColor", awakeColorRim);
        
      
        _renderer.SetPropertyBlock(_propBlock);
        
    }
}
