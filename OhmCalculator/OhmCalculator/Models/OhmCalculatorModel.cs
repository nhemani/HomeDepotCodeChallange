using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmCalculator.Models
{
    public class CalculatorModel {

        public IEnumerable<System.Web.Mvc.SelectListItem> ColorList {get;set;}
        public IEnumerable<System.Web.Mvc.SelectListItem> MultiplierColorList { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> ToleranceColorList { get; set; }
        public string BandColorA { get; set; }
        public string BandColorB { get; set; }
        public string Multiplier { get; set; }
        public string Tolerance { get; set; }
    }
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var result = 0;
            if(IsNumeric(bandAColor) && IsNumeric(bandBColor) && IsNumeric(bandCColor))
            {
                var bands = Convert.ToInt32(bandAColor + bandBColor);
                var multiplier = Convert.ToInt32(bandCColor);
                result = bands * multiplier;
            }

            return result;
        }

        private bool IsNumeric(string s)
        {
            try
            {
                Double.Parse(s);
            }
            catch
            {
                return (false);
            }
            return (true);
        }
    }

    public interface IOhmValueCalculator
    {

        /// <summary>

        /// Calculates the Ohm value of a resistor based on the band colors.

        /// </summary>

        /// <param name="bandAColor">The color of the first figure of component value band.</param>

        /// <param name="bandBColor">The color of the second significant figure band.</param>

        /// <param name="bandCColor">The color of the decimal multiplier band.</param>

        /// <param name="bandDColor">The color of the tolerance value band.</param>

        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

    }
}