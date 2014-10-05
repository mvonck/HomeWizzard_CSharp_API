using System;
using System.Collections.Generic;
using HomeWizzardConnector.Models;
using HomeWizzardConnector.Models.Enums;

namespace HomeWizzardConnector
{
    public interface IHomeWizzardService
    {
        /// <summary>
        /// Get all switchNumbers
        /// </summary>
        /// <returns></returns>
        IEnumerable<Switch> GetSwitchNumbers();

        /// <summary>
        /// Get all sensors
        /// </summary>
        /// <returns></returns>
        SensorsCollection GetSensors();

        /// <summary>
        /// Get all scenes
        /// </summary>
        /// <returns></returns>
        IEnumerable<Scene> GetScenes(); 

        /// <summary>
        /// Turns a switch on or off
        /// </summary>
        /// <param name="switchId"></param>
        /// <param name="switchEnum"></param>
        void SwitchDevice(int switchId, SwitchEnum switchEnum);

        /// <summary>
        /// Turns a switch on or off
        /// </summary>
        /// <param name="sceneId"></param>
        /// <param name="switchEnum"></param>
        void SwitchScene(int sceneId, SwitchEnum switchEnum);

        /// <summary>
        /// Operate dimmer
        /// </summary>
        /// <param name="value">value 0 ... 255</param>
        /// <exception cref="ArgumentOutOfRangeException">if value is not between 0 and 255</exception>
        void OperateDimmer(Int16 value);
    }
}
