namespace Arinc.Spec424.Tests;

public class LoadTests
{
    private readonly string[] strings = File.ReadAllLines("data/ru.txt");

    [Fact]
    public void Load()
    {
        var data = Data424.Load(strings);

        Assert.NotEmpty(data.Airports);
        Assert.NotEmpty(data.AirportApproaches);
        Assert.NotEmpty(data.ControlledAirspaces);
        Assert.NotEmpty(data.CruisingTables);
        Assert.NotEmpty(data.Airways);
        Assert.NotEmpty(data.FlightInfoRegions);
        Assert.NotEmpty(data.HoldingPatterns);
        Assert.NotEmpty(data.RestrictiveAirspaces);
        Assert.NotEmpty(data.Runways);
        Assert.NotEmpty(data.AirportInstrumentDepartures);
        Assert.NotEmpty(data.AirportTerminalArrivals);
        Assert.NotEmpty(data.OmnidirectionalStations);
        Assert.NotEmpty(data.NonDirectionalBeacons);
    }
}
