namespace DataAccess.Data;

internal static class SeedData
{
    internal static List<Domain.Models.Company> GetCompanyBaseData() =>
    [
        new()
        {
            Id = 1,
            Name = "Microsoft",
            Description = "Microsoft Corporation is an American multinational technology company which produces computer software, consumer electronics, personal computers, and related services.",
            Industry = "Technology",
            Location = "Redmond, WA",
            EmployeeNumber = 225321
        },
        new()
        {
            Id = 2,
            Name = "Amazon",
            Description = "Amazon.com, Inc. is an American multinational technology company which focuses on e-commerce, cloud computing, digital streaming, and artificial intelligence.",
            Industry = "Technology",
            EmployeeNumber = 1660000,
            Location = "Seattle, WA"
        },
        new()
        {
            Id = 3,
            Name = "The LEGO Group",
            Description = "The LEGO Group is a Danish toy production company based in Billund. It is best known for the manufacture of LEGO-brand toys, consisting mostly of interlocking plastic bricks.",
            Industry = "Plastic Manufacturing",
            EmployeeNumber = 32301,
            Location = "Billund"
        },
        new()
        {
            Id = 4,
            Name = "Facebook",
            Description = "Facebook, Inc. is an American multinational technology conglomerate based in Menlo Park, California. It was founded by Mark Zuckerberg, along with his fellow roommates and students at Harvard College.",
            Industry = "Technology",
            EmployeeNumber = 60654,
            Location = "Menlo Park, CA"
        },
        new()
        {
            Id = 5,
            Name = "Apple",
            Description = "Apple Inc. is an American multinational technology company that specializes in consumer electronics, computer software, and online services.",
            Industry = "Technology",
            EmployeeNumber = 147000,
            Location = "Cupertino, CA"
        }
    ];

    internal static List<Domain.Models.User> GetUserBaseData() =>
    [
        new Domain.Models.User()
        {
            Id = 1,
            FirstName = "Philip",
            LastName = "Krag Nielsen",
            Email = "philip.nielsen@lego.com",
            PasswordHash = "123456",
            JobTitle = "Associate Software Engineer",
            CompanyId = 3
        },
        new()
        {
            Id = 2,
            FirstName = "Bill",
            LastName = "Gates",
            Email = "bill.gates@microsoft.com",
            PasswordHash = "123456",
            JobTitle = "Co-Founder",
            CompanyId = 1
        },
        new()
        {
            Id = 3,
            FirstName = "Jeff",
            LastName = "Dunham",
            Email = "jeff.dunham@facebook.com",
            PasswordHash = "123456",
            JobTitle = "Senior Technology Manager",
            CompanyId = 4
        },
        new()
        {
            Id = 4,
            FirstName = "Tim",
            LastName = "O'Malley",
            Email = "tim.omalley@facebook.com",
            PasswordHash = "123456",
            JobTitle = "Lead Engineer",
            CompanyId = 4
        },
        new()
        {
            Id = 5,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@apple.com",
            PasswordHash = "123456",
            JobTitle = "Software Manager",
            CompanyId = 5
        },
        new()
        {
            Id = 6,
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane.doe@apple.com",
            PasswordHash = "123456",
            JobTitle = "Software Engineer",
            CompanyId = 5
        },
        new()
        {
            Id = 7,
            FirstName = "Steven",
            LastName = "Ogg",
            Email = "trevor.philips@amazon.com",
            PasswordHash = "123456",
            JobTitle = "Chief Technology Officer",
            CompanyId = 2
        }
    ];

    internal static List<Domain.Models.JobPost> GetJobPostsBaseData() =>
    [
        new()
        {
            Id = 1,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 1,
            HiringManagerId = 2
        },
        new()
        {
            Id = 2,
            Title = "Lead Software Architect - Join us now!",
            Description = "We are looking for a lead software architect to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C", "C++", "Architecture", "Design Patterns", "Rust", "C#"],
            CompanyId = 1,
            HiringManagerId = 2
        },
        new()
        {
            Id = 3,
            Title = "Junior Software Engineer - Join our team!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["Python", "Powershell", "Bash"],
            CompanyId = 2,
            HiringManagerId = 7
        },
        new()
        {
            Id = 4,
            Title = "Looking for an Observability Engineer",
            Description = "We are looking for an experienced observability engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["OpenTelemetry", "Elastic Stack", "APM", "Metrics", "System Insight"],
            CompanyId = 3,
            HiringManagerId = 1
        },
        new()
        {
            Id = 5,
            Title = "Software Engineer - Join our team!",
            Description = "We are looking for a senior software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["Java", "Spring Boot", "Kubernetes", "Docker"],
            CompanyId = 4,
            HiringManagerId = 3
        },
        new()
        {
            Id = 6,
            Title = "Senior Software Engineer - Join our team!",
            Description = "We are looking for a senior software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 4,
            HiringManagerId = 3
        },
        new()
        {
            Id = 7,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 5,
            HiringManagerId = 5
        },
        new()
        {
            Id = 8,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 1,
            HiringManagerId = 2
        },
        new()
        {
            Id = 9,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 4,
            HiringManagerId = 4
        },
        new()
        {
            Id = 10,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 5,
            HiringManagerId = 6
        },
        new()
        {
            Id = 11,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            CompanyId = 2,
            HiringManagerId = 7
        },
        new()
        {
            Id = 12,
            Title = "Software Engineer - Open position!",
            Description = "We are looking for a software engineer to join our team. You will be working on the latest technologies and help us build the next generation of software products.",
            Skills = ["C#", ".NET", "Azure", "SQL"],
            
            CompanyId = 3,
            HiringManagerId = 1
        }
    ];
}
