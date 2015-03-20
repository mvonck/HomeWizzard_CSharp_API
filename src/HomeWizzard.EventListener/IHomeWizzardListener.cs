using HomeWizzard.EventListener.SensorEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWizzard.EventListener
{
    public interface IHomeWizzardListener
    {
        ISensorEventListener SensorEventListener { get; }
    }
}
