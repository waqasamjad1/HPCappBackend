using HPCapp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HPCapp.BL
{
   public class ShipProcessor: IShipProcessor
    {
        public bool ShipIDDetails(ShipDetail ship)
        {
            if (ship.id == null || ship.id == Guid.Empty)
            {
                throw new ArgumentNullException("Employee ID cannot be empty");
            }

            return true;

        }


        public bool ShipCodeDetails(ShipDetail Ship)
        {
            if (!Regex.Match(Ship.code, "[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{2}").Success)
            {
                throw new ArgumentNullException("Invalid Code Format");

            }

              return true;

        }
    }
}
