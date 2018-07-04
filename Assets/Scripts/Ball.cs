using System.Timers;
using UnityEngine;

public class Ball
{
    Timer energyTimer = new Timer(1000);
    private float speed = 5f;
    private float energy = 100f;
    private float max_energy = 100f;

    public void TimerStart()
    {
        energyTimer.Elapsed += Counter;
        energyTimer.Enabled = true;
        energyTimer.Start();
    }

    private void Counter(object source, ElapsedEventArgs e)
    {
        if(energy < max_energy)
        {
            Debug.Log("energy+++");
            energy++;
        }
            
    }

    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    public float Energy
    {
        set { energy = value; }
        get { return energy; }
    }
    
    public float MaxEnergy
    {
        set { max_energy = value; }
        get { return max_energy; }
    }

   
}
