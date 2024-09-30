namespace CodingAssignment.src.Models.GetBikeThefts
{
    public class SearchParams
    {
        public string? Serial { get; set; }
        public string? Query { get; set; }
        public string? Manufacturer { get; set; }
        public string? CycleType { get; set; }
        public string? PropulsionType { get; set; }
        public string? Colors { get; set; }
        public Stolenness Stolenness { get; set; } = Stolenness.stolen;
        public string Location { get; set; } = "IP";
        public int Distance { get; set; } = 10;
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 25;
    }
}
