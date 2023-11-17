// using SOSResources.Models;


// namespace SOSResources.Data
// {
//     public static class DbInitializer
//     {
//         public static void Initialize(SchoolContext context)
//         {
//             // Look for any students.
//             if (context.Students.Any())
//             {
//                 return;   // DB has been seeded
//             }

//             var alexander = new Student
//             {
//                 FirstMidName = "Carson",
//                 LastName = "Alexander",
//                 EnrollmentDate = DateTime.Parse("2016-09-01")
//             };

//             var alonso = new Student
//             {
//                 FirstMidName = "Meredith",
//                 LastName = "Alonso",
//                 EnrollmentDate = DateTime.Parse("2018-09-01")
//             };

//             var anand = new Student
//             {
//                 FirstMidName = "Arturo",
//                 LastName = "Anand",
//                 EnrollmentDate = DateTime.Parse("2019-09-01")
//             };

//             var barzdukas = new Student
//             {
//                 FirstMidName = "Gytis",
//                 LastName = "Barzdukas",
//                 EnrollmentDate = DateTime.Parse("2018-09-01")
//             };

//             var li = new Student
//             {
//                 FirstMidName = "Yan",
//                 LastName = "Li",
//                 EnrollmentDate = DateTime.Parse("2018-09-01")
//             };

//             var justice = new Student
//             {
//                 FirstMidName = "Peggy",
//                 LastName = "Justice",
//                 EnrollmentDate = DateTime.Parse("2017-09-01")
//             };

//             var norman = new Student
//             {
//                 FirstMidName = "Laura",
//                 LastName = "Norman",
//                 EnrollmentDate = DateTime.Parse("2019-09-01")
//             };

//             var olivetto = new Student
//             {
//                 FirstMidName = "Nino",
//                 LastName = "Olivetto",
//                 EnrollmentDate = DateTime.Parse("2011-09-01")
//             };

//             var students = new Student[]
//             {
//                 alexander,
//                 alonso,
//                 anand,
//                 barzdukas,
//                 li,
//                 justice,
//                 norman,
//                 olivetto
//             };

//             context.AddRange(students);


//             var gebusi = new Department
//             {
//                 Title = "The Gebusi: Rainforest Living",
//                 Author = "Bruce Knauft",
//                 Edition = 5,
//                 Quantity = 3,
//             };

//            var caseHealth = new Department{
//             Title = "Case Studies for Health, Research and Practice in Australia and New Zealand",
//             Author = "Nicola Whiteing",
//             Quantity = 1
//            };

//             var departments = new Department[]
//             {
//                 gebusi,
//                 caseHealth
//             };

//             context.AddRange(departments);

//             var chemistry = new Course
//             {
//                 CourseID = 1050,
//                 Title = "Chemistry",
//                 Credits = 3,
//             };

//             var microeconomics = new Course
//             {
//                 CourseID = 4022,
//                 Title = "Microeconomics",
//                 Credits = 3,

//             };

//             var macroeconmics = new Course
//             {
//                 CourseID = 4041,
//                 Title = "Macroeconomics",
//                 Credits = 3,

//             };

//             var calculus = new Course
//             {
//                 CourseID = 1045,
//                 Title = "Calculus",
//                 Credits = 4,

//             };

//             var trigonometry = new Course
//             {
//                 CourseID = 3141,
//                 Title = "Trigonometry",
//                 Credits = 4,

//             };

//             var composition = new Course
//             {
//                 CourseID = 2021,
//                 Title = "Composition",
//                 Credits = 3,
//                 Department = gebusi,
//             };

//             var literature = new Course
//             {
//                 CourseID = 2042,
//                 Title = "Literature",
//                 Credits = 4,
//                 Department = gebusi,
//             };

//             var courses = new Course[]
//             {
//                 chemistry,
//                 microeconomics,
//                 macroeconmics,
//                 calculus,
//                 trigonometry,
//                 composition,
//                 literature
//             };

//             context.AddRange(courses);

//             var enrollments = new Enrollment[]
//             {
//                 new Enrollment {
//                     Student = alexander,
//                     Course = chemistry,
//                     Grade = Grade.A
//                 },
//                 new Enrollment {
//                     Student = alexander,
//                     Course = microeconomics,
//                     Grade = Grade.C
//                 },
//                 new Enrollment {
//                     Student = alexander,
//                     Course = macroeconmics,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = alonso,
//                     Course = calculus,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = alonso,
//                     Course = trigonometry,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = alonso,
//                     Course = composition,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = anand,
//                     Course = chemistry
//                 },
//                 new Enrollment {
//                     Student = anand,
//                     Course = microeconomics,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = barzdukas,
//                     Course = chemistry,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = li,
//                     Course = composition,
//                     Grade = Grade.B
//                 },
//                 new Enrollment {
//                     Student = justice,
//                     Course = literature,
//                     Grade = Grade.B
//                 }
//             };

//             context.AddRange(enrollments);
//             context.SaveChanges();
//         }
//     }
// }