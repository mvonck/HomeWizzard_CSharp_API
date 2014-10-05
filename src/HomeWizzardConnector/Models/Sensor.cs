
namespace HomeWizzardConnector.Models
{
    public class Sensor
    {
        public Sensor()
        {
        }

        internal Sensor(HWConnector.JsonResult.Models.Sensor jsonObject)
        {
            Id = jsonObject.Id;
            Name = jsonObject.Name;
            IsFavorite = jsonObject.IsFavorite;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsFavorite { get; set; }
    }
}
