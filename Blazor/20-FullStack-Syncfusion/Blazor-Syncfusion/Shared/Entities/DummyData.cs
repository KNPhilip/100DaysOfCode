namespace BlazorSyncfusion.Shared.Entities
{
    public class DummyData
    {
        public static List<Employee> GridData { get; set; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Kenneth",
                LastName = "Hougaard Soerensen",
                NickName = "KESO",
                Title = "Lærer",
                Mail = "keso@aspit.dk",
                School = "AspIT Trekanten",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 2,
                FirstName = "Mads",
                LastName = "Mikkel Rasmussen",
                NickName = "MARA",
                Title = "Lærer",
                Mail = "mara@aspit.dk",
                School = "AspIT Trekanten",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 3,
                FirstName = "Dea",
                LastName = "Gram",
                NickName = "DEGR",
                Title = "Lærer",
                Mail = "degr@aspin.dk",
                School = "AspIN",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 4,
                FirstName = "Jan",
                LastName = "Lindgaard Pedersen",
                NickName = "JAPE",
                Title = "Lærer",
                Mail = "jape@aspin.dk",
                School = "AspIN",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 5,
                FirstName = "Jesper",
                LastName = "Lade Mathiesen",
                NickName = "JEMA",
                Title = "Specialpædagogisk vejleder",
                Mail = "jema@aspit.dk",
                Phone = "+45 72 16 28 56",
                School = "AspIT Trekanten",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 6,
                FirstName = "Henrik",
                LastName = "Stephansen",
                NickName = "HENS",
                Title = "Praktik- og jobvejleder",
                Mail = "hens@aspit.dk",
                Phone = "+45 72 16 26 85",
                School = "AspIT Trekanten",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            },
            new Employee
            {
                Id = 7,
                FirstName = "Ole",
                LastName = "Bay Jensen",
                NickName = "OJE",
                Title = "Uddannelseschef",
                Mail = "oje@aspit.dk",
                Phone = "+45 72 16 27 99",
                School = "AspIT Trekanten",
                IsEmployee = true,
                BirthDate = new DateTime(1994, 03, 04)
            }
        };
    }
}