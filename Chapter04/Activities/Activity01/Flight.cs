namespace Chapter04.Activities.Activity01
{
    internal record Flight (string Agency, double PaidFair, string TripType, string RoutingType, string TicketClass,
        string DepartureDate, string Origin, string Destination, string DestinationCountry,
        string Carrier);
}
