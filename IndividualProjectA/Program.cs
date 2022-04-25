using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IndividualProjectA
{
    class Program
    {
        public static List<Student> findDublicates(List<Student> allstudents)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i< allstudents.Count; i++)
            {
                for (int z=0; z < i; z++)
                {
                    if (allstudents[z].FirstName == allstudents[i].FirstName && allstudents[z].LastName == allstudents[i].LastName)
                    {
                        result.Add(new Student()  { FirstName = allstudents[z].FirstName, LastName = allstudents[z].LastName, DateOfBirth=allstudents[z].DateOfBirth, TuitionFees=allstudents[z].TuitionFees});
                        break;
                    }
                }
            }
            return result;
        }
        public static void findSubmissionsInRange(List<AssignmentsPerStudent> assignmentPerStudentList)
        {
            Console.WriteLine("Give me the Date of submisson");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            string day = dt.DayOfWeek.ToString();
            if (day == "Monday")
            {
                startDate = dt;
                endDate = dt.AddDays(4);
            }
            else if (day == "Tuesday")
            {
                startDate = dt.AddDays(-1);
                endDate = dt.AddDays(3);
            }
            else if (day == "Wednesday")
            {
                startDate = dt.AddDays(-2);
                endDate = dt.AddDays(2);
            }
            else if (day == "Thursday")
            {
                startDate = dt.AddDays(-3);
                endDate = dt.AddDays(1);
            }
            else if (day == "friday")
            {
                startDate = dt.AddDays(-4);
                endDate = dt;
            }
            else if (day == "Saturday")
            {
                startDate = dt.AddDays(-5);
                endDate = dt.AddDays(-1);
            }
            else if (day == "Sunday")
            {
                startDate = dt.AddDays(-6);
                endDate = dt.AddDays(-2);
            }
            bool found = false;
            Console.WriteLine($"Student's assignments with submisson date between {startDate} and {endDate}");
            Console.WriteLine("____________________________________________________________________________");
            foreach (AssignmentsPerStudent assignmentsPerStudent in assignmentPerStudentList)
            {
                foreach (var s in assignmentsPerStudent.Assignments)
                {
                    if (s.SubDateTime > startDate && s.SubDateTime < endDate)
                    {
                        found = true;
                        Console.WriteLine($"Student : {assignmentsPerStudent.FirstName} {assignmentsPerStudent.LastName} - Date of Birth: {assignmentsPerStudent.DateOfBirth} - Tuition Fees: {assignmentsPerStudent.TuitionFees} ");
                        break;
                    }

                }
            }
            if (found == false) Console.WriteLine($"There are no assignments with submisson date between {startDate} and {endDate}");
        }
        static void Main(string[] args)
        {
            int choice = 8;
            List<Course> courseList = new List<Course>();
            List<Student> studentList = new List<Student>();
            List<Trainer> trainerList = new List<Trainer>();
            List<Assignment> assignmentList = new List<Assignment>();
            List<StudentsPerCourse> studentsPerCourseList = new List<StudentsPerCourse>();
            List<TrainersPerCourse> trainersPerCourseList = new List<TrainersPerCourse>();
            List<AssignmentsPerCourse> assignmentsPerCourseList = new List<AssignmentsPerCourse>();
            List<AssignmentsPerStudent> assignmentPerStudentList = new List<AssignmentsPerStudent>();
            do
            {
                Console.WriteLine("-------------------Individual Part A--------------------");
                Console.WriteLine("Press 0 to add the Courses");
                Console.WriteLine("Press 1 to add the Students");
                Console.WriteLine("Press 2 to add the Trainers");
                Console.WriteLine("Press 3 to add the Assignments");
                Console.WriteLine("Press 4 to add the Students per Course");
                Console.WriteLine("Press 5 to add the Trainers per Course");
                Console.WriteLine("Press 6 to add the Assignments per Course");
                Console.WriteLine("Press 7 to add the Assignments per Student");
                Console.WriteLine("Press 8 to produce synthetic data");
                Console.WriteLine("Press 9 to continue with my data");

                choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    int epilogh = 0;

                    do
                    {
                        Course course = new Course();
                        Console.WriteLine("Give the Course Title");
                        course.Title = Console.ReadLine();
                        Console.WriteLine("Give the Course Stream");
                        course.Stream = Console.ReadLine();
                        Console.WriteLine("Give the Course Type");
                        course.Type = Console.ReadLine();
                        Console.WriteLine("Give the Start Date");
                        course.Start_Date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the End Date");
                        course.End_Date = DateTime.Parse(Console.ReadLine());
                        courseList.Add(course);
                        Console.WriteLine("Add another Course? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 1)
                {
                    int epilogh = 0;

                    do
                    {
                        Student student = new Student();
                        Console.WriteLine("Give the Student First Name");
                        student.FirstName = Console.ReadLine();
                        Console.WriteLine("Give the Student Last Name");
                        student.LastName = Console.ReadLine();
                        Console.WriteLine("Give the Date Of Birth");
                        student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the Tuition Fees");
                        student.TuitionFees = double.Parse(Console.ReadLine());
                        studentList.Add(student);
                        Console.WriteLine("Add another Student? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 2)
                {
                    int epilogh = 0;

                    do
                    {
                        Trainer trainer = new Trainer();
                        Console.WriteLine("Give the Trainer First Name");
                        trainer.FirstName = Console.ReadLine();
                        Console.WriteLine("Give the Trainer Last Name");
                        trainer.LastName = Console.ReadLine();
                        Console.WriteLine("Give the Trainer's subject");
                        trainer.Subject = Console.ReadLine();                        
                        trainerList.Add(trainer);
                        Console.WriteLine("Add another Trainer? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 3)
                {
                    int epilogh = 0;

                    do
                    {
                        Assignment assignment = new Assignment();
                        Console.WriteLine("Give the Assignment Title");
                        assignment.Title = Console.ReadLine();
                        Console.WriteLine("Give the Assignment Description");
                        assignment.Description = Console.ReadLine();
                        Console.WriteLine("Give the Submission Date ");
                        assignment.SubDateTime = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the Oral Mark");
                        assignment.OralMark = int.Parse(Console.ReadLine());
                        Console.WriteLine("Give the Total Mark");
                        assignment.TotalMark = int.Parse(Console.ReadLine());
                        assignmentList.Add(assignment);
                        Console.WriteLine("Add another Assignment? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 4)
                {
                    int epilogh = 0;

                    do
                    {
                        StudentsPerCourse studentsPerCourse = new StudentsPerCourse();
                        Console.WriteLine("Give the Course Title");
                        studentsPerCourse.Title = Console.ReadLine();
                        Console.WriteLine("Give the Course Stream");
                        studentsPerCourse.Stream = Console.ReadLine();
                        Console.WriteLine("Give the Course Type");
                        studentsPerCourse.Type = Console.ReadLine();
                        Console.WriteLine("Give the Start Date");
                        studentsPerCourse.Start_Date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the End Date");
                        studentsPerCourse.End_Date = DateTime.Parse(Console.ReadLine()); 
                        int ch = 0;
                        studentsPerCourse.Students = new List<Student>();
                        do
                        {
                            Student student = new Student();
                            Console.WriteLine("Give the Student First Name");
                            student.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Student Last Name");
                            student.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Date Of Birth");
                            student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Tuition Fees");
                            student.TuitionFees = double.Parse(Console.ReadLine());                            
                            studentsPerCourse.Students.Add(student);
                            Console.WriteLine("Add another Student? Press 1  for yes or 0 for no");
                            ch = int.Parse(Console.ReadLine());
                        } while (ch != 0);
                        studentsPerCourseList.Add(studentsPerCourse);
                        Console.WriteLine("Add another Course? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 5)
                {
                    int epilogh = 0;

                    do
                    {
                        TrainersPerCourse trainersPerCourse = new TrainersPerCourse();
                        Console.WriteLine("Give the Course Title");
                        trainersPerCourse.Title = Console.ReadLine();
                        Console.WriteLine("Give the Course Stream");
                        trainersPerCourse.Stream = Console.ReadLine();
                        Console.WriteLine("Give the Course Type");
                        trainersPerCourse.Type = Console.ReadLine();
                        Console.WriteLine("Give the Start Date");
                        trainersPerCourse.Start_Date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the End Date");
                        trainersPerCourse.End_Date = DateTime.Parse(Console.ReadLine());
                        
                        int ch = 0;
                        trainersPerCourse.Trainers = new List<Trainer>();
                        do // fills the list with the trainers 
                        {
                            Trainer trainer = new Trainer();
                            Console.WriteLine("Give the Trainer First Name");
                            trainer.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Trainer Last Name");
                            trainer.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Trainer's subject");
                            trainer.Subject = Console.ReadLine(); ;
                            trainersPerCourse.Trainers.Add(trainer);
                            Console.WriteLine("Add another Trainer? Press 1  for yes or 0 for no");
                            ch = int.Parse(Console.ReadLine());
                        } while (ch != 0);
                        trainersPerCourseList.Add(trainersPerCourse);
                        Console.WriteLine("Add another Course? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 6)
                {
                    int epilogh = 0;

                    do
                    {
                        AssignmentsPerCourse assignmentsPerCourse = new AssignmentsPerCourse();
                        Console.WriteLine("Give the Course Title");
                        assignmentsPerCourse.Title = Console.ReadLine();
                        Console.WriteLine("Give the Course Stream");
                        assignmentsPerCourse.Stream = Console.ReadLine();
                        Console.WriteLine("Give the Course Type");
                        assignmentsPerCourse.Type = Console.ReadLine();
                        Console.WriteLine("Give the Start Date");
                        assignmentsPerCourse.Start_Date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the End Date");
                        assignmentsPerCourse.End_Date = DateTime.Parse(Console.ReadLine());

                        int ch = 0;
                        assignmentsPerCourse.Assignments = new List<Assignment>();
                        do // fills the list with the assignments 
                        {
                            Assignment assignment = new Assignment();
                            Console.WriteLine("Give the Assignment Title");
                            assignment.Title = Console.ReadLine();
                            Console.WriteLine("Give the Assignment Description");
                            assignment.Description = Console.ReadLine();
                            Console.WriteLine("Give the Submission Date ");
                            assignment.SubDateTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Oral Mark");
                            assignment.OralMark = int.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Total Mark");
                            assignment.TotalMark = int.Parse(Console.ReadLine());
                            assignmentsPerCourse.Assignments.Add(assignment);
                            Console.WriteLine("Add another Assignment? Press 1  for yes or 0 for no");
                            ch = int.Parse(Console.ReadLine());
                        } while (ch != 0);
                        assignmentsPerCourseList.Add(assignmentsPerCourse);
                        Console.WriteLine("Add another Course? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 7)
                {
                    int epilogh = 0;

                    do
                    {
                        AssignmentsPerStudent assignmentsPerStudent = new AssignmentsPerStudent();
                        Console.WriteLine("Give the Student First Name");
                        assignmentsPerStudent.FirstName = Console.ReadLine();
                        Console.WriteLine("Give the Student Last Name");
                        assignmentsPerStudent.LastName = Console.ReadLine();
                        Console.WriteLine("Give the Date Of Birth");
                        assignmentsPerStudent.DateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the Tuition Fees");
                        assignmentsPerStudent.TuitionFees = double.Parse(Console.ReadLine());

                        assignmentsPerStudent.Course = new Course();                        
                        Console.WriteLine("Give the Course Title");
                        assignmentsPerStudent.Course.Title = Console.ReadLine();                       
                        Console.WriteLine("Give the Course Stream");
                        assignmentsPerStudent.Course.Stream = Console.ReadLine();
                        Console.WriteLine("Give the Course Type");
                        assignmentsPerStudent.Course.Type = Console.ReadLine();
                        Console.WriteLine("Give the Start Date");
                        assignmentsPerStudent.Course.Start_Date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Give the End Date");
                        assignmentsPerStudent.Course.End_Date = DateTime.Parse(Console.ReadLine());

                        int ch = 0;
                        assignmentsPerStudent.Assignments = new List<Assignment>();
                        do
                        {
                            Assignment assignment = new Assignment();
                            Console.WriteLine("Give the Assignment Title");
                            assignment.Title = Console.ReadLine();
                            Console.WriteLine("Give the Assignment Description");
                            assignment.Description = Console.ReadLine();
                            Console.WriteLine("Give the Submission Date ");
                            assignment.SubDateTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Oral Mark");
                            assignment.OralMark = int.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Total Mark");
                            assignment.TotalMark = int.Parse(Console.ReadLine());
                            assignmentsPerStudent.Assignments.Add(assignment);
                            Console.WriteLine("Add another Assignment? Press 1  for yes or 0 for no");
                            ch = int.Parse(Console.ReadLine());
                        } while (ch != 0);
                        assignmentPerStudentList.Add(assignmentsPerStudent);
                        Console.WriteLine("Add another Student? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
            } while (choice != 8 && choice != 9 );
            if (choice == 8) //produce syntetic data;
            {
                 courseList = new List<Course>()
                {
                    new Course() { Title="C Sharp", Stream="C#", Type="Full Time", Start_Date=new DateTime(2019,09,01), End_Date= new DateTime(2020,02,20)},
                    new Course() { Title="Javascript", Stream="JS", Type="Full Time", Start_Date=new DateTime(2019,09,01), End_Date= new DateTime(2020,02,20)},
                    new Course() { Title="Python Programming Language", Stream="Python", Type="Part Time", Start_Date=new DateTime(2019,09,01), End_Date= new DateTime(2020,06,28)},
                    new Course() { Title="Java Programming Language", Stream="Java", Type="Full Time", Start_Date=new DateTime(2019,09,01), End_Date= new DateTime(2020,02,28)},
                };

                studentList = new List<Student>()
                {
                    new Student() { FirstName="Theodore", LastName="Stassinos", DateOfBirth=new DateTime(1977,02,28), TuitionFees=2500},
                    new Student() { FirstName="George", LastName="Euthymiou", DateOfBirth=new DateTime(1987,03,18), TuitionFees=2500},
                    new Student() { FirstName="John", LastName="Makris", DateOfBirth=new DateTime(1990,10,18), TuitionFees=2500},
                    new Student() { FirstName="Kostas", LastName="Giannopoulos", DateOfBirth=new DateTime(1995,12,15), TuitionFees=2500}

                };

                trainerList = new List<Trainer>()
                {
                    new Trainer() { FirstName = "George", LastName = "Kapetanakis", Subject = "Javascript"},
                    new Trainer() { FirstName = "Marios", LastName = "Maltzis", Subject = "C#"},
                    new Trainer() { FirstName = "John", LastName = "Georgiou", Subject = "Python"},
                    new Trainer() { FirstName = "Kyriakos", LastName = "Papadopoulos", Subject = "Java"}

                };

                assignmentList = new List<Assignment>()
                {
                    new Assignment() { Title = "Assignment 1", Description = "The first Assignment", SubDateTime =new DateTime(2020,02,02)},
                    new Assignment() { Title = "Assignment 2", Description = "The second Assignment", SubDateTime =new DateTime(2020,06,01)},
                    new Assignment() { Title = "Individual Project A", Description = "The first Individual Project", SubDateTime =new DateTime(2020,12,12)},
                    new Assignment() { Title = "Individual Project B", Description = "The second Individual Project", SubDateTime =new DateTime(2021,01,01)},

                };

                studentsPerCourseList = new List<StudentsPerCourse>()
                {
                    new StudentsPerCourse()
                    {
                        Title = "C Sharp",
                        Stream = "C#",
                        Type = "Full Time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Students = new List<Student>()
                        { 
                            new Student() { FirstName= "Theodore", LastName="Stassinos", DateOfBirth=new DateTime(1977,02,28),TuitionFees=2500 },
                            new Student() { FirstName= "Marios", LastName="Maltzis", DateOfBirth=new DateTime(1987,12,24),TuitionFees=2500},
                            new Student() { FirstName= "Kyriakos", LastName="Papatheodorou", DateOfBirth=new DateTime(1989,03,08),TuitionFees=2500},
                            new Student() { FirstName= "John", LastName="Giannakos", DateOfBirth=new DateTime(1999,04,17),TuitionFees=2500 },
                            new Student() { FirstName= "Nikos", LastName="Parianos", DateOfBirth=new DateTime(1988,06,14),TuitionFees=2500}

                        }
                    },
                    new StudentsPerCourse()
                    {
                        Title = "Java Programming",
                        Stream = "Java",
                        Type = "Full Time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Students = new List<Student>()
                        {
                            new Student() { FirstName= "Theodore", LastName="Stassinos", DateOfBirth=new DateTime(1977,02,28),TuitionFees=2500 },
                            new Student() { FirstName= "Mihalis", LastName="Hatzigiannis", DateOfBirth=new DateTime(1985,12,20),TuitionFees=2500 },
                            new Student() { FirstName= "Nikos", LastName="Parianos", DateOfBirth=new DateTime(1988,06,14),TuitionFees=2500},
                            new Student() { FirstName= "Andreas", LastName="Sveltos", DateOfBirth=new DateTime(2000,05,18),TuitionFees=2500},
                            new Student() { FirstName= "Theodore", LastName="Pappas", DateOfBirth=new DateTime(2001,09,04),TuitionFees=2500 },
                            new Student() { FirstName= "John", LastName="Giannakos", DateOfBirth=new DateTime(1999,04,17),TuitionFees=2500 },
                            new Student() { FirstName= "Giorgos", LastName="Papatheodorou", DateOfBirth=new DateTime(1989,03,08),TuitionFees=2500}

                        }
                    }

                };
                trainersPerCourseList = new List<TrainersPerCourse>()
                {
                    new TrainersPerCourse()
                    {
                        Title = "C Sharp",
                        Stream = "C#",
                        Type = "Full time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Trainers = new List<Trainer>()
                        { 
                            new Trainer() { FirstName = "Panos", LastName ="Theodoropoulos", Subject = "C#"},
                            new Trainer() { FirstName = "George", LastName ="Karamitros", Subject = "C#"},
                            new Trainer() { FirstName = "Giannis", LastName ="Papathanasiou", Subject = "Javascript"},
                            new Trainer() { FirstName = "George", LastName ="Ntalaras", Subject = "Java"}
                        }
                    },
                    new TrainersPerCourse()
                    {
                        Title = "Java Programming",
                        Stream = "Java",
                        Type = "Full time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Trainers = new List<Trainer>()
                        {
                            new Trainer() { FirstName = "Fotis", LastName ="Apostolopoulos", Subject = "Java"},
                            new Trainer() { FirstName = "Marios", LastName ="Kyriakou", Subject = "Python"},
                            new Trainer() { FirstName = "Haris", LastName ="Tsavlos", Subject = "JavaScript"},
                            new Trainer() { FirstName = "Kwstas", LastName ="Kwstantinou", Subject = "Java"}
                        }
                    }
                };
                assignmentsPerCourseList = new List<AssignmentsPerCourse>()
                {
                    new AssignmentsPerCourse()
                    {
                        Title = "Java Programming",
                        Stream = "Java",
                        Type = "Full time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Assignments= new List<Assignment>()
                        {
                            new Assignment() { Title = "Assignment 1", Description = "The first Assignment", SubDateTime =new DateTime(2020,02,02)},
                            new Assignment() { Title = "Assignment 2", Description = "The second Assignment", SubDateTime =new DateTime(2020,06,01)},
                            new Assignment() { Title = "Individual Project A", Description = "The first Individual Project", SubDateTime =new DateTime(2020,12,12)},
                            new Assignment() { Title = "Individual Project B", Description = "The second Individual Project", SubDateTime =new DateTime(2021,01,01)}
                        }
                    },
                    new AssignmentsPerCourse()
                    {
                        Title = "C# programming",
                        Stream = "C#",
                        Type = "Full time",
                        Start_Date = new DateTime(2022,02,28),
                        End_Date = new DateTime(2022,09,30),
                        Assignments= new List<Assignment>()
                        {
                            new Assignment() { Title = "Assignment 3", Description = "The third Assignment", SubDateTime =new DateTime(2020,02,02)},
                            new Assignment() { Title = "Assignment 4", Description = "The fourth Assignment", SubDateTime =new DateTime(2020,06,01)},
                            new Assignment() { Title = "Individual Project A", Description = "The first Individual Project", SubDateTime =new DateTime(2020,12,12)},
                            new Assignment() { Title = "Individual Project B", Description = "The second Individual Project", SubDateTime =new DateTime(2021,01,01)}
                        }
                    }
                };
                assignmentPerStudentList = new List<AssignmentsPerStudent>()
                {
                    new AssignmentsPerStudent()
                    {
                        FirstName = "Theodore",
                        LastName = "Stassinos",
                        DateOfBirth = new DateTime(1977,02,28),
                        TuitionFees = 2500,
                        Course = new Course()
                        {
                            Title = "Java Programming",
                            Stream = "Java",
                            Type = "Full Time",
                            Start_Date = new DateTime(2019,01,01),
                            End_Date = new DateTime(2020,06,30)
                        },
                        Assignments = new List<Assignment>()
                        {
                            new Assignment() { Title = "Assignment 1", Description= "My first Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =80, TotalMark=90},
                            new Assignment() { Title = "Assignment 2", Description= "My Second Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =70, TotalMark=80},
                            new Assignment() { Title = "Individual Project A", Description= "My third Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =90, TotalMark=95}
                        }

                    },
                    new AssignmentsPerStudent()
                    {
                        FirstName = "George",
                        LastName = "Thalassinos",
                        DateOfBirth = new DateTime(1987,02,18),
                        TuitionFees = 2500,
                        Course = new Course()
                        {
                            Title = "Python Programming",
                            Stream = "Python",
                            Type = "Full Time",
                            Start_Date = new DateTime(2019,01,01),
                            End_Date = new DateTime(2020,06,30)
                        },
                        Assignments = new List<Assignment>()
                        {
                            new Assignment() { Title = "Assignment 1", Description= "My first Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =80, TotalMark=90},
                            new Assignment() { Title = "Assignment 2", Description= "My Second Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =70, TotalMark=80},
                            new Assignment() { Title = "Individual Project A", Description= "My third Assgnment", SubDateTime = new DateTime(2020,06,30), OralMark =90, TotalMark=95}
                        }

                    }

                };

            }

            //Type the list of all objects;
            Console.WriteLine("----------------Courses-----------------");
            foreach (Course course in courseList)
            {
                Console.WriteLine($"Course Title: {course.Title} - Stream: {course.Stream} - Type: {course.Type} - Start Date: {course.Start_Date} - End Date: {course.End_Date}");              
            }
            Console.WriteLine("----------------Students-----------------");

            foreach (Student student in studentList)
            {
                Console.WriteLine($"Student First Name: {student.FirstName} - Last Name: {student.LastName} - Date of Birth: {student.DateOfBirth} - Tuition Fees: {student.TuitionFees} ");
            }

            Console.WriteLine("----------------Trainers-----------------");

            foreach (Trainer trainer in trainerList)
            {
                Console.WriteLine($"Trainer's First Name: {trainer.FirstName} - Last Name: {trainer.LastName} - Subject: {trainer.Subject} ");
            }

            Console.WriteLine("----------------Assignments-----------------");

            foreach (Assignment assignment in assignmentList)
            {
                Console.WriteLine($"Assignment Title: {assignment.Title} - Description: {assignment.Description} - Submission Date: {assignment.SubDateTime} - Oral Mark: {assignment.OralMark} - Total Mark: {assignment.TotalMark}");
            }
            Console.WriteLine("----------------Students Per Course-----------------");

            foreach (StudentsPerCourse studentsPerCourse in studentsPerCourseList)
            {
                Console.WriteLine($"Course Title: {studentsPerCourse.Title} - Stream: {studentsPerCourse.Stream} - Type: {studentsPerCourse.Type} - Start Date: {studentsPerCourse.Start_Date} - End Date: {studentsPerCourse.End_Date}");
                foreach(var s in studentsPerCourse.Students)
                {
                    Console.WriteLine($"\t Student First Name: {s.FirstName} - Last Name: {s.LastName} -  Date of Birth: {s.DateOfBirth} - Tuition Fees: {s.TuitionFees}");
                }
            }
            Console.WriteLine("----------------Trainers Per Course-----------------");

            foreach (TrainersPerCourse trainersPerCourse in trainersPerCourseList)
            {
                Console.WriteLine($"Course Title: {trainersPerCourse.Title} - Stream: {trainersPerCourse.Stream} - Type: {trainersPerCourse.Type} - Start Date: {trainersPerCourse.Start_Date} - End Date: {trainersPerCourse.End_Date}");
                foreach (var s in trainersPerCourse.Trainers)
                {
                    Console.WriteLine($"\t Student First Name: {s.FirstName} - Last Name: {s.LastName} -  Subject: {s.Subject}");
                }
            }

            Console.WriteLine("----------------Assignments Per Course-----------------");

            foreach (AssignmentsPerCourse assignmentsPerCourse in assignmentsPerCourseList)
            {
                Console.WriteLine($"Course Title: {assignmentsPerCourse.Title} - Stream: {assignmentsPerCourse.Stream} - Type: {assignmentsPerCourse.Type} - Start Date: {assignmentsPerCourse.Start_Date} - End Date: {assignmentsPerCourse.End_Date}");
                foreach (var s in assignmentsPerCourse.Assignments)
                {
                    Console.WriteLine($"\t Assignment Title: {s.Title} - Description: {s.Description} - Submission Date: {s.SubDateTime} - Oral Mark: {s.OralMark} - Total Mark: {s.TotalMark}");
                }
            }

            Console.WriteLine("----------------Assignments Per Student-----------------");

            foreach (AssignmentsPerStudent assignmentsPerStudent in assignmentPerStudentList)
            {
                Console.WriteLine($"Student : {assignmentsPerStudent.FirstName} {assignmentsPerStudent.LastName} - Date of Birth: {assignmentsPerStudent.DateOfBirth} - Tuition Fees: {assignmentsPerStudent.TuitionFees} ");
                Console.WriteLine($"\t Course Title: {assignmentsPerStudent.Course.Title} - Stream: {assignmentsPerStudent.Course.Stream} - Type: {assignmentsPerStudent.Course.Type} - Start Date: {assignmentsPerStudent.Course.Start_Date} - End Date: {assignmentsPerStudent.Course.End_Date}");
                foreach (var s in assignmentsPerStudent.Assignments)
                {
                    Console.WriteLine($"\t\t Assignment Title: {s.Title} - Description: {s.Description} - Submission Date: {s.SubDateTime} - Oral Mark: {s.OralMark} - Total Mark: {s.TotalMark}");                  
                }
            }

            Console.WriteLine("-------------------Find Dublicates-------------------------");
            List<Student> allstudents = new List<Student>();
            foreach (StudentsPerCourse studentsPerCourse in studentsPerCourseList)
            {
                foreach (var s in studentsPerCourse.Students)
                {
                    allstudents.Add(new Student() { FirstName = s.FirstName, 
                                                    LastName = s.LastName, 
                                                    DateOfBirth = s.DateOfBirth, 
                                                    TuitionFees = s.TuitionFees });
                }
            }
            List<Student> duplicates = findDublicates(allstudents);
            foreach (var x in duplicates)
            {
                Console.WriteLine($" Name: {x.FirstName} {x.LastName} Date of birth: {x.DateOfBirth} Tuition Fees: {x.TuitionFees} takes more than one course");
            }

            Console.WriteLine("-----------------------Find Submissions------------------------------");
            findSubmissionsInRange(assignmentPerStudentList);

        }
    }
}
