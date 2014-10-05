using HomeWizzardConnector.Models.Enums;

namespace HomeWizzardConnector.Models
{
    public class SwitchNumber
    {
        public SwitchNumber()
        {
        }

        internal SwitchNumber(HWConnector.JsonResult.Models.SwitchNumber jsonObject)
        {
            Id = jsonObject.Id;
            Name = jsonObject.Name;
            Type = jsonObject.Type;
            Status = jsonObject.Status.ToPublicEnum();
            IsFavorite = jsonObject.IsFavorite;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public SwitchEnum Status { get; set; }

        public bool IsFavorite { get; set; }
    }
}
