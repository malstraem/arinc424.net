namespace Arinc.Spec424.Tests;

public class LoadTests
{
    private readonly string[] strings = File.ReadAllLines("data/russia.txt");

    [Fact]
    public void Load()
    {
        var data = ArincData424.Load(strings);

        Assert.NotEmpty(data.Airports);
        Assert.NotEmpty(data.AirportApproaches);
        Assert.NotEmpty(data.ControlledAirspaces);
        Assert.NotEmpty(data.CruisingTables);
        Assert.NotEmpty(data.Airways);
        Assert.NotEmpty(data.FlightInfoRegions);
        Assert.NotEmpty(data.HoldingPatterns);
        Assert.NotEmpty(data.RestrictiveAirspaces);
        Assert.NotEmpty(data.Runways);
        Assert.NotEmpty(data.StandardInstrumentDepartures);
        Assert.NotEmpty(data.StandardTerminalArrivals);
        Assert.NotEmpty(data.Waypoints);
        Assert.NotEmpty(data.VeryHighFrequencyAids);
        Assert.NotEmpty(data.NonDirectionalBeacons);
    }
}
