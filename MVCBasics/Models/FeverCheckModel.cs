using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class FeverCheckModel
    {
        [Required]
        [MaxLength(4)]
        public static float TemperatureValue { get; set; }
        [Required]
        [MaxLength(1)]
        public static String TemperatureScale { get; set; }

        public static String EvaluateTemperature(float temperatureValue, String temperatureScale)
        {
            TemperatureValue = temperatureValue;
            TemperatureScale = temperatureScale;

            float feverThreshold = temperatureScale.Equals("C") ? 37.5f : 99.5f;
            float hypothermiaThreshold = temperatureScale.Equals("C") ? 35.0f : 95.0f;

            if (temperatureValue > feverThreshold)
            {
                return $"You Have A Fever! [ {temperatureValue} °{temperatureScale} > {feverThreshold} °{temperatureScale} ]";
            }
            else if (temperatureValue < hypothermiaThreshold)
            {
                return $"You Have A Hypothermia! [ {temperatureValue} °{temperatureScale} < {hypothermiaThreshold} °{temperatureScale} ]";
            }
            else
            {
                return "Your Body Temperature Appears to Be Normal!";
            }
        }
        //public static String EvaluateTemperature(int temperatureValue, String temperatureScale)
        //{
        //    return "result";
        //}
    }
}
