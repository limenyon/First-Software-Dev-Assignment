using System;
using System.Collections.Generic;
using System.Text;

namespace SoftDevAss1
{
    public interface ILightManager //creating an interface to be used with stubs and mocks to simulate these classes being used
    {
        string GetStatus(); //get status of lights

        void SetAllLights(bool isOn); //change the states of all lights
    }
}
