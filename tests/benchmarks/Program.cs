using BenchmarkDotNet.Running;

using Arinc424.Bench;

BenchmarkRunner.Run<LoadBench>();
//BenchmarkRunner.Run<MetaBench>();

Console.ReadLine();
