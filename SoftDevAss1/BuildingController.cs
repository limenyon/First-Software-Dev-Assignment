using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftDevAss1
{
    public class BuildingController
    {
        public string buildingID;
        public string currentState;
        public string errorMessage = "Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'";
        public BuildingController(string id, string startState) //the constructor used to initialise two parameters that every offshoot of this class will have
        {
            buildingID = id.ToLower();
            currentState = startState;
        }
        public string GetBuildingID() //a function that returns the ID we just set above through a constructor
        {
            return buildingID;
        }
        public string GetCurrentState() //A function that returns the state of the controller, unlike getbuildingID it will change with setcurrentstate
        {
            return currentState;
        }
        public bool SetCurrentState(string newState, string[] possibleStates, string startState) //Changing or keeping the variable currentState 
        {
            for (int i = 0; i <= possibleStates.Length - 1; i++)
            {
                if (newState == possibleStates[i]) //check if the new state provided is even legal in this context
                {
                    if (newState == currentState) //an output for when the new state is the same as the current one to prevent issues
                    {
                        return true;
                    }
                    else if (currentState != startState && startState != newState) //returning false whenever someone tries to set states outside of the intended order
                    {
                        return false;
                    }
                    else
                    {
                        currentState = newState; //setting a new state
                        return true;
                    }
                }
            }
            return false;
            throw new ArgumentException(errorMessage); //if the new state put in is not part of the possible states list throw an exception and return false
        }
        public class LightManager : ILightManager //using the interface created in ILightManager.cs to get status of lights and set every lgiht to a different state
        {
            public string GetStatus()
            {
                throw new NotImplementedException();
            }
            public void SetAllLights(bool isOn)
            {
                throw new NotImplementedException();
            }

        }
    }
}