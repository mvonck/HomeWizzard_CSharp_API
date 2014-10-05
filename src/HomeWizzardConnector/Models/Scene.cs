namespace HomeWizzardConnector.Models
{
    public class Scene : Sensor
    {
        public Scene() : base()
        {
        }

        internal Scene(HWConnector.JsonResult.Models.Scene jsonObject) : base(jsonObject)
        { }
    }
}
