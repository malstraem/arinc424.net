using BenchmarkDotNet.Running;

using Arinc424.Bench;
using Arinc424.Ports;

BenchmarkRunner.Run<LoadBench>();
BenchmarkRunner.Run<MetaBench>();

Console.ReadLine();


void SetName(Airport airport, string name)
{
    airport.Name = name;
}
