namespace Arinc.Spec424.Tests;

public class LoadTests
{
    [Theory]
    [InlineData("ru.txt")]
    [InlineData("world.txt")]
    public void Load(string file)
    {
        var data = Data424.Load(File.ReadAllLines($"data/{file}"));

        Assert.NotEmpty(data.Airports);
        Assert.NotEmpty(data.AirportApproaches);
        Assert.NotEmpty(data.ControlledAirspaces);
        Assert.NotEmpty(data.CruisingTables);
        Assert.NotEmpty(data.Airways);
        Assert.NotEmpty(data.FlightInfoRegions);
        Assert.NotEmpty(data.HoldingPatterns);
        Assert.NotEmpty(data.RestrictiveAirspaces);
        Assert.NotEmpty(data.Runways);
        Assert.NotEmpty(data.AirportDepartures);
        Assert.NotEmpty(data.AirportArrivals);
        Assert.NotEmpty(data.OmnidirectionalStations);
        Assert.NotEmpty(data.NonDirectionalBeacons);
    }
}
