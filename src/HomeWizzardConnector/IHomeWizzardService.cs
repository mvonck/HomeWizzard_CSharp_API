using System;
using System.Collections.Generic;
using HomeWizzardConnector.Models;
using HomeWizzardConnector.Models.Enums;
using System.Threading.Tasks;

namespace HomeWizzardConnector
{
    public interface IHomeWizzardService
    {
        /// <summary>
        /// Get all switchNumbers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Switch>> GetSwitchNumbersAsync();

        /// <summary>
        /// Get all sensors
        /// </summary>
        /// <returns></returns>
        Task<SensorsCollection> GetSensorsAsync();

        /// <summary>
        /// Get all scenes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Scene>> GetScenesAsync(); 

        /// <summary>
        /// Turns a switch on or off
        /// </summary>
        /// <param name="switchId"></param>
        /// <param name="status"></param>
        Task SetSwitchAsync(int switchId, SwitchStatus status);

        /// <summary>
        /// Turns a switch on or off
        /// </summary>  
        /// <param name="sceneId"></param>
        /// <param name="status"></param>
        Task SetSceneAsync(int sceneId, SwitchStatus status);

        /// <summary>
        /// Operate dimmer
        /// </summary>
        /// <param name="dimmerId">The id of the dimmer to operate.</param>
        /// <param name="dimmerNumber">value between 0 and 255</param>
        /// <exception cref="ArgumentOutOfRangeException">if value is not between 0 and 255</exception>
        Task OperateDimmerAsync(int dimmerId, short dimmerNumber);
    }
}
