using UnityEngine;


public class Synapse : WormBase
{
    public float activity { get { return income; } }
    public Vector3 drawPos;
    public bool select;
    public float income;
    public float threshold;

    public Synapse(float threshold, string _name, Vector3 pos) : base(_name, pos)
    {
        select = false;
        //activity = 0;
        income = 0;
        this.threshold = threshold;
        mName = _name;
    }

    public void ReceiveSignal(float signal)
    {
        income += signal * 0.1f;
    }

    public virtual void checkActivity()
    {
        income = Mathf.Min(income, 1.0f);

        income *= 0.9f;
    }
}
