using HPCapp.Models;
using System;


namespace HPCapp.BL
{
    interface IShipProcessor
    {
         bool ShipIDDetails(ShipDetail Ship);
        bool ShipCodeDetails(ShipDetail Ship);
    }
}
