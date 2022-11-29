namespace AOC2021;

public class Day1
{
    readonly List<int> inputs;

    public Day1(List<int> inputs)
    {
        this.inputs = inputs;
    }
    public Day1(List<string> inputs)
    {
        this.inputs = inputs.Select(x => Int32.Parse(x)).ToList();
    }

    public int Solve(int window = 1)
    {

        // var windowed_output = inputs.Select((floor_measurement,index) => new {floor_measurement, floor_group = Math.Floor((double)index/window)});
        // //var grouped_windows_output = windowed_output.GroupBy(x=> Math.Floor());
        // var grouped_windows_output =
        //     from floor in windowed_output
        //     group floor by floor.floor_group into floorGroup
        //     select new
        //     {
        //         FloorGroup = floorGroup.Key,
        //         TotalMeasurement = floorGroup.Sum(x=> x.floor_measurement),
        //         MeasurementCounts = floorGroup.Count()
        //     };

        // var test = grouped_windows_output.Where(x => x.MeasurementCounts == window).OrderBy(x => x.FloorGroup).Select(x => x.TotalMeasurement).ToList();
        // var grouped_windows_output = windowed_output.GroupBy(
        // x => Int32.Parse(x.floor_group), (floor_measurement, floor_group) => new {Key = floor_group, Sum=floor_measurement.Sum()}
        
        int number_larger_than_previous = 0;
        for(int i=1; i<inputs.Count; i++){
            try
            {
                if (inputs.GetRange(i,window).Sum() > inputs.GetRange(i-1,window).Sum()) number_larger_than_previous++;
            }
            catch (ArgumentException)
            {
                break;
            }
        }
        return number_larger_than_previous;
    }
}