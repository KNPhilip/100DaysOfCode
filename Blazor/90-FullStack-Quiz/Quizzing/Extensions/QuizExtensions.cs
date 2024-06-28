using Quizzing.Models;

namespace Quizzing.Extensions;

public static class QuizExtensions
{
    public static void LoadDotNetQuestions(this List<Question> Questions)
    {
        Questions.AddRange([
            new()
            {
                QuestionTitle = "Why would you use asynchronous programming?",
                Options = ["To release the quest thread of a I/O operation.", "To capture the request thread of a I/O operation.",
                    "To avoid blocking the request thread while waiting for an I/O operation.", "To block the request thread if it waits for an I/O operation."],
                Answer = "To avoid blocking the request thread while waiting for an I/O operation."
            },
            new()
            {
                QuestionTitle = "In C#, what is the default access modifier for class members?",
                Options = ["Public", "Internal", "Private", "Protected"],
                Answer = "Private"
            },
            new()
            {
                QuestionTitle = "What does language interoperability refer to?",
                Options = ["The ability to complement one language with another.", "A language with a garbage collector.", 
                    "How flexible a language is (polymorphic behavior, dynamic approaches, etc.)", "It does not mean anything."],
                Answer = "The ability to complement one language with another."
            },
            new()
            {
                QuestionTitle = "In C#, what does the lock statement do?",
                Options = ["Prevents a class from being inherited.", "Ensures that a block of code runs without interruption by multiple threads.",
                    "Prevents a method from being overridden.", "Creates a new instance of a class."],
                Answer = "Ensures that a block of code runs without interruption by multiple threads."
            },
            new()
            {
                QuestionTitle = "What is the difference between covariance and contravariance?",
                Options = ["In C#, covariance and contravariance disable implicit reference conversion for array types, delegate types, and generic type arguments. Contravariance preserves assignment compatibility and covariance reverses it.",
                    "In C#, covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. Covariance preserves assignment compatibility and contravariance reverses it.",
                    "In C#, covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. Contravariance preserves assignment compatibility and covariance reverses itIn C#, covariance and contravariance disable implicit reference conversion for array types, delegate types, and generic type arguments. Contravariance preserves assignment compatibility and covariance reverses it.",
                    "In C#, covariance and contravariance disables implicit reference conversion for array types, delegate types, and generic type arguments. Covariance preserves assignment compatibility and contravariance reverses it."],
                Answer = "In C#, covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. Covariance preserves assignment compatibility and contravariance reverses it."
            },
            new()
            {
                QuestionTitle = "You want to create an instance of several families of classes. Which design pattern best fits this objective?",
                Options = ["Decorator", "Singleton", "Abstract Factory", "Bridge"],
                Answer = "Abstract Factory"
            },
            new()
            {
                QuestionTitle = "In what C# version was primary constructors introduced?",
                Options = ["12", "10", "7", "9"],
                Answer = "12"
            },
            new()
            {
                QuestionTitle = "When would you use generics in your code?",
                Options = ["To increase code performance.", "All of these answers apply.", "when code reuse is a priority.", "when type safety is important."],
                Answer = "All of these answers apply."
            },
            new()
            {
                QuestionTitle = "What is a sealed class?",
                Options = ["A class that cannot be inherited from.", "An immutable class.", 
                    "A class that cannot be directly instantiated.", "A class which can only be instantiated once."],
                Answer = "A class that cannot be inherited from."
            },
            new()
            {
                QuestionTitle = "Where is the struct stored?",
                Options = ["The Entity Framework database", "The Heap", "The Stack", "Nowhere, it doesn't need to be."],
                Answer = "The Stack"
            },
            new()
            {
                QuestionTitle = "What is a thread?",
                Options = ["A delivery mechanism for utilizing the CPU.", "A text-based Facebook post.", 
                    "A series of connected posts.", "All of these."],
                Answer = "All of these."
            },
            new()
            {
                QuestionTitle = "When an object in C# is serialized, what is it converted to?",
                Options = ["JSON", "XML", "Byte stream", "Value stream"],
                Answer = "Byte stream"
            }
        ]);
    }

    public static void LoadBlazorQuestions(this List<Question> Questions)
    {
        Questions.AddRange([
            new()
            {
                QuestionTitle = "Which method is used to navigate to a different page in a Blazor application?",
                Options = ["Navigate()", "Redirect()", "NavigationManager.NavigateTo()", "Url.Change()"],
                Answer = "NavigationManager.NavigateTo()"
            },
            new()
            {
                QuestionTitle = "How can you utilize JavaScript in Blazor?",
                Options = ["Through Microsoft's component library", "This is not possible.", "With the static JSWorker class.", "With the IJSRuntime interface."],
                Answer = "With the IJSRuntime interface."
            },
            new()
            {
                QuestionTitle = "When was Blazor launched?",
                Options = ["September 2019", "January 2007", "July 2011", "April 2016"],
                Answer = "September 2019"
            },
            new()
            {
                QuestionTitle = "How many render modes are available in Blazor?",
                Options = ["7", "3", "5", "4"],
                Answer = "4"
            },
            new()
            {
                QuestionTitle = "What is Razor in the context of Blazor?",
                Options = ["A syntax for combining HTML and C#.", "All of these.", "C#'s version of JSX.", "A way to create the pages in Blazor."],
                Answer = "All of these."
            },
            new()
            {
                QuestionTitle = "Which of the render modes requires extra effort to create?",
                Options = ["SSR, due to no default interactivity.", "WebAssembly Mode, due to its downloading time.", "Server Mode, since it requires Web Socket setup.", "None of them."],
                Answer = "SSR, due to no default interactivity."
            },
            new()
            {
                QuestionTitle = "Who are one of the people behind Blazor?",
                Options = ["Bjarne Stroustrup", "Patrick God", "Neil Cummings", "Steve Sanderson"],
                Answer = "Steve Sanderson"
            },
            new()
            {
                QuestionTitle = "What is Syncfusion?",
                Options = ["A component library.", "A way to use synchronous programming in Blazor.", "A Blazor specific ORM, just like Entity Framework.", "The engine behind IoC."],
                Answer = "A component library."
            },
            new()
            {
                QuestionTitle = "What is Blazor United?",
                Options = ["The working title of .NET 8 Blazor.", "This definitive version of Blazor.", "The first version of Blazor.", "Blazor with MAUI."],
                Answer = "The working title of .NET 8 Blazor."
            }
        ]);
    }

    public static void LoadGitQuestions(this List<Question> Questions)
    {
        Questions.AddRange([
            new()
            {
                QuestionTitle = "Why would you use a pre-receive hook in your remote repository?",
                Options = ["You wouldn't, you would use it in the local repository.", "To execute a script when a remote receives a push that is triggered before any refs are updated.",
                    "To fire a script after updates are made to the remote repository.", "To debug all commit tags and release versions."],
                Answer = "To execute a script when a remote receives a push that is triggered before any refs are updated."
            },
            new()
            {
                QuestionTitle = "Inside a GitHub action, which keyword do you use to specify the operating system to run jobs?",
                Options = ["operating-system", "runnersystem", "runs-on", "os"],
                Answer = "runs-on"
            },
            new()
            {
                QuestionTitle = "In a situation where you have several commits for a single task, what is the most efficient way to restructure your commit history?",
                Options = ["Cherry pick the related commits to another branch.", "Delete the task commits and recommit with a new message.",
                    "Squash the related commits together into a single coherent commit.", "Stash the related commits under a new hash."],
                Answer = "Squash the related commits together into a single coherent commit."
            },
            new()
            {
                QuestionTitle = "What command finds the HEAD of the current branch?",
                Options = ["git head --verify", "git log --head", "git hash --head", "git show-ref --head"],
                Answer = "git show-ref --head"
            },
            new()
            {
                QuestionTitle = "Who made git?",
                Options = ["Philip Krag Nielsen", "Linus Torvalds", "David Heinemeier Hansson", "Dennis Ritchie"],
                Answer = "Linus Torvalds"
            },
            new()
            {
                QuestionTitle = "What command would you use to stage changes to the index strictly for properties files in the current directory?",
                Options = ["git add *.properties", "git add %.properties", "git add .properties", "git add properties"],
                Answer = "git add *.properties"
            }
        ]);
    }

    public static void LoadScrumQuestions(this List<Question> Questions)
    {
        Questions.AddRange([
            new()
            {
                QuestionTitle = "What is the role of Management once an organization has adopted Scrum?",
                Options = ["The Management hires the people needed and forms the Scrum Teams.", "The Management is decoupled from Scrum and has no role.",
                    "The Management is expected to set a vision and a direction for the business. It supports the Product Owner with business insights and helps the Scrum Master in causing change within the organization.",
                    "There is no Management once an organization adopts Scrum. There is no place for Management in Scrum."],
                Answer = "The Management is expected to set a vision and a direction for the business. It supports the Product Owner with business insights and helps the Scrum Master in causing change within the organization."
            },
            new()
            {
                QuestionTitle = "Why should the Sprint Review be held at the same time and same place Sprint after Sprint?",
                Options = ["To make it easier to book rooms in advance.", "To reduce complexity and overhead.", "The Stakeholders know where and when to come without being invited.",
                    "To lower costs."],
                Answer = "To reduce complexity and overhead."
            },
            new()
            {
                QuestionTitle = "When can the Scrum Master cancel the Sprint?",
                Options = ["Never. Only the Product Owner can cancel the Sprint.", "When all the Product Backlog Items are completed.",
                    "When the Product Owner has not explained the business requirements.", "When the Sprint Goal is no longer achievable or obsolete."],
                Answer = "Never. Only the Product Owner can cancel the Sprint."
            },
            new()
            {
                QuestionTitle = "Some of the requirements in the Sprint Backlog are unclear, and the Developers don’t think they can deliver a working Product Increment by the end of the Sprint. What should the Scrum Master do?",
                Options = ["The Developers did their best. Ask the Product Owner to accept the work as it is.", "Tell them to focus on reaching the Sprint Goal. That is more important than the Increment.",
                    "Cancel the Sprint and organize a Sprint Retrospective.", "Coach the Developers to work together with the Product Owner."],
                Answer = "Coach the Developers to work together with the Product Owner."
            },
            new()
            {
                QuestionTitle = "When is the Sprint Review held?",
                Options = ["Before the Product Increment has been released.", "As soon as one Product Backlog Item meets the Definition of Done.",
                    "When the Product Owner decides.", "At the end of the Sprint."],
                Answer = "At the end of the Sprint."
            },
            new()
            {
                QuestionTitle = "Who has the final say on the order of the Product Backlog during the Sprint Review meeting?",
                Options = ["The Product Owner.", "The Stakeholders.", "The CEO of the company.", "The Scrum Team."],
                Answer = "The Product Owner."
            },
            new()
            {
                QuestionTitle = "Who manages the Product Backlog?",
                Options = ["The Developers.", "The Scrum Team.", "The Product Owner.", "The Scrum Master."],
                Answer = "The Product Owner."
            },
            new()
            {
                QuestionTitle = "When jointly developing a Product, how should two Scrum Teams work toward integrating their work?",
                Options = ["Each Scrum Team should have an area of expertise and handle a single subsystem or layer of the Product. This ensures efficiency and reduces the need for meetings with the other team. Work can be integrated before a release as soon as this is announced.",
                    "Each Scrum Team should work through all subsystems or layers of functionality. Both teams continually work together to produce at least an integrated Product Increment by the end of each Sprint.", 
                    "None of these answers are correct.",
                    "The Product Owner and the Scrum Master should decide based on their experience and guide the teams."],
                Answer = "Each Scrum Team should work through all subsystems or layers of functionality. Both teams continually work together to produce at least an integrated Product Increment by the end of each Sprint."
            },
            new()
            {
                QuestionTitle = "How can the Developers increase the transparency of the Product Increment?",
                Options = ["Updating the Scrum Board during or immediately after the Daily Scrum.", "Doing the work required according to the Definition of Done.",
                    "It is not the responsibility of the Developers. The Scrum Master should report the current progress to the Product Owner, Stakeholders, or the Management.",
                    "Reporting to the stakeholders the current progress on the Product Increment"],
                Answer = "Doing the work required according to the Definition of Done."
            },
            new()
            {
                QuestionTitle = "Which of the following is one of the accountabilities of the Scrum Master?",
                Options = ["Promoting and supporting Scrum.", "Maximizing the value resulting from the work of the Scrum Team.",
                    "Managing the Sprint progress (by using practices such as burn-down charts).", "Managing the resources and making sure that all capacities are appropriately allocated."],
                Answer = "Promoting and supporting Scrum."
            },
            new()
            {
                QuestionTitle = "The Scrum Team must release each Product Increment _____",
                Options = ["after the Sprint Review.", "when testing is done and the Definition of Done is met.", "when the Users of the Product request it.",
                    "when it makes sense."],
                Answer = "when it makes sense."
            },
            new()
            {
                QuestionTitle = "Upon what sort of process control theory is Scrum established?",
                Options = ["Lightweight", "Empirical", "Experimental", "Agile"],
                Answer = "Empirical"
            },
            new()
            {
                QuestionTitle = "What purpose does the Project Kick-off Sprint serve?",
                Options = ["Planning the project in detail for the next Sprints.", "There is no such thing in Scrum.", "Creating the Product Backlog.",
                    "The Product Owner gathers requirements and creates the Product Backlog, and the Developers work on the technical setup needed to start working on the Product."],
                Answer = "There is no such thing in Scrum."
            },
            new()
            {
                QuestionTitle = "Why should the Sprint Review be held at the same time and same place Sprint after Sprint?",
                Options = ["Reallocate resources from other teams if they have free capacities.", "Change the Sprint Goal to match the work that can be accomplished.",
                    "Do nothing until the Sprint Retrospective. Use the meeting to improve.", "Renegotiate the selected Product Backlog Items with the Developers to meet the Sprint Goal."],
                Answer = "Renegotiate the selected Product Backlog Items with the Developers to meet the Sprint Goal."
            },
            new()
            {
                QuestionTitle = "Which of the following is correct regarding the Product Owner?",
                Options = ["The Product Owner's primary tool for maximizing value is the Sprint Backlog.", "The Product Owner is accountable for maximizing the value.",
                    "The Product Owner cannot be part of multiple Scrum Teams.", "When delegating work, the Product Owner is no longer accountable for the work that was delegated."],
                Answer = "The Product Owner is accountable for maximizing the value."
            }
        ]);
    }
}
