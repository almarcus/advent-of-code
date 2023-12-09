using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AOC2023;

public class Day5
{
    public List<Map> Maps { get; set; } = new List<Map>();
    public List<SourceDestinationMap> SeedstoSoilMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> SoiltoFertilizerMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> FertilizertoWaterMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> WatertoLightMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> LighttoTemperatureMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> TemperaturetoHumidityMaps { get; set; } = new List<SourceDestinationMap>();
    public List<SourceDestinationMap> HumiditytoLocationMaps { get; set; } = new List<SourceDestinationMap>();

    public Day5(string input)
    {
        
        foreach (var section in input.Split("\n\n"))
        {
            if (section.StartsWith("seeds: "))
                Maps = section.Substring(7).Split(" ").Select(e => new Map(int.Parse(e))).ToList();
            else if (section.StartsWith("seed-to-soil map:"))
            {
                SeedstoSoilMaps = GetMaps(section);

            }
            else if (section.StartsWith("soil-to-fertilizer map:"))
            {
                SoiltoFertilizerMaps = GetMaps(section);
            }
            else if (section.StartsWith("fertilizer-to-water map:"))
            {
                FertilizertoWaterMaps = GetMaps(section);
            }
            else if (section.StartsWith("water-to-light map:"))
            {
                WatertoLightMaps = GetMaps(section);
            }
            else if (section.StartsWith("light-to-temperature map:"))
            {
                LighttoTemperatureMaps = GetMaps(section);
            }
            else if (section.StartsWith("temperature-to-humidity map:"))
            {
                TemperaturetoHumidityMaps = GetMaps(section);
            }
            else if (section.StartsWith("humidity-to-location map:"))
            {
                HumiditytoLocationMaps = GetMaps(section);
            }
        }
    }

    public List<SourceDestinationMap> GetMaps(string input)
    {
        List<SourceDestinationMap> maps = new List<SourceDestinationMap>();
        foreach (var line in input.Split("\n").Skip(1))
        {
            maps.Add(new SourceDestinationMap(line));
        }
        return maps;
    }

    public double Solve1()
    {
        foreach (var map in Maps)
        {
            map.MapSeedsToSoil(SeedstoSoilMaps);
            map.MapSoilToFertilizer(SoiltoFertilizerMaps);
            map.MapFertilizerToWater(FertilizertoWaterMaps);
            map.MapWaterToLight(WatertoLightMaps);
            map.MapLightToTemperature(LighttoTemperatureMaps);
            map.MapTemperatureToHumidity(TemperaturetoHumidityMaps);
            map.MapHumidityToLocation(HumiditytoLocationMaps);
        }
        return Maps.Min(e => e.Location);
    }
    public double Solve2() => throw new NotImplementedException();

    public class Map
    {
        public int Seed { get; set; }
        public int Soil { get; set; }
        public int Fertilizer { get; set; }
        public int Water { get; set; }
        public int Light { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Location { get; set; }

        public Map() { }

        public Map(int seed, int soil, int fertilizer, int water, int light, int temperature, int humidity, int location)
        {
            Seed = seed;
            Soil = soil;
            Fertilizer = fertilizer;
            Water = water;
            Light = light;
            Temperature = temperature;
            Humidity = humidity;
            Location = location;
        }

        public Map(int seed)
        {
            Seed = seed;
            Soil = seed;
            Fertilizer = seed;
            Water = seed;
            Light = seed;
            Temperature = seed;
            Humidity = seed;
            Location = seed;
        }

        public void MapSeedsToSoil(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Soil = map.GetDestination(Seed) ?? Seed;
            }

            // Soil = Seed;
        }

        public void MapSoilToFertilizer(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Fertilizer = map.GetDestination(Soil) ?? Soil;
            }
        }

        public void MapFertilizerToWater(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Water = map.GetDestination(Fertilizer) ?? Fertilizer;
            }
        }

        public void MapWaterToLight(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Light = map.GetDestination(Water) ?? Water;
            }
        }

        public void MapLightToTemperature(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Temperature = map.GetDestination(Light) ?? Light;
            }
        }

        public void MapTemperatureToHumidity(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Humidity = map.GetDestination(Temperature) ?? Temperature;
            }
        }

        public void MapHumidityToLocation(List<SourceDestinationMap> sourceDestinationMaps)
        {
            foreach (var map in sourceDestinationMaps)
            {
                Location = map.GetDestination(Humidity) ?? Humidity;
            }
        }

        public override string ToString()
        {
            return $"Seed {Seed}, Soil {Soil}, Fertilizer {Fertilizer}, Water {Water}, Light {Light}, Temperature {Temperature}, Humidity {Humidity}, Location {Location}";
        }
    }

    public class SourceDestinationMap
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Length { get; set; }

        public SourceDestinationMap(string input)
        {
            string[] split_input = input.Split(" ");
            Destination = int.Parse(split_input[0]);
            Source = int.Parse(split_input[1]);
            Length = int.Parse(split_input[2]);
        }

        public SourceDestinationMap(int source, int destination, int length)
        {
            Source = source;
            Destination = destination;
            Length = length;
        }

        private int? GetDestination(int current, int source, int destination, int length)
        {
            if (current >= source && current <= (source + length))
                return destination + (current - source);
            else
                return null;
        }

        public int? GetDestination(int current)
        {
            return GetDestination(current, Source, Destination, Length);
            
        }
    }

    // Range range = new Range(98, 99)
    
}
