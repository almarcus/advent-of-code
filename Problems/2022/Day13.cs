using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AOC2022;

public class Day13
{

    public class Packet
    {
        JsonNode left;
        JsonNode right;

        public bool IsInRightOrder => Compare(left, right);

        private static bool Compare(JsonNode left, JsonNode right)
        {
            var leftArray = (left as JsonArray);
            var rightArray = (right as JsonArray);
            for(int i = 0; i < leftArray.Count; i++)
            {
                if (leftArray[i] is JsonArray)
                {
                    if (!Compare(leftArray[i], rightArray[i]))
                        return false;
                }
                else if (int.Parse(leftArray[i].ToString()) > int.Parse(rightArray[i].ToString()))
                    return false;
            }

            return true;
        }

        public Packet(JsonNode left, JsonNode right)
        {
            this.left = left;
            this.right = right;
        }
    }
    List<Packet> packets = new();

    public Day13(string input)
    {
        foreach(var packetPairs in input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries))
        {
            var pair = packetPairs.Split("\n");
            JsonNode left = JsonNode.Parse(pair[0])!;
            JsonNode right = JsonNode.Parse(pair[1])!;

            packets.Add(new Packet(left,right));
        }
    }
}