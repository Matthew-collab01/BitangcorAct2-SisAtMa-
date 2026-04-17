namespace attedanceModels {

    public class attModels {
        public Guid ident { get; set; }
        public string studname { get; set; } = string.Empty;
        public int Present { get; set; }

        public int Absent { get; set; }
        public int TotalDays { get; set; }
}
}
