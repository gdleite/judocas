using judocas.Models;
using System;
using System.Linq;

namespace judocas.Data
{
    public static class DbInitializer
    {
        public static void Initialize(judocasContext context)
        {
            

            // look for any students.
            if (context.Filiados.Any())
            {
                return;   // db has been seeded
            }

            //var students = new student[]
            //{
            //new student{firstmidname="carson",lastname="alexander",enrollmentdate=datetime.parse("2005-09-01")},
            //new student{firstmidname="meredith",lastname="alonso",enrollmentdate=datetime.parse("2002-09-01")},
            //new student{firstmidname="arturo",lastname="anand",enrollmentdate=datetime.parse("2003-09-01")},
            //new student{firstmidname="gytis",lastname="barzdukas",enrollmentdate=datetime.parse("2002-09-01")},
            //new student{firstmidname="yan",lastname="li",enrollmentdate=datetime.parse("2002-09-01")},
            //new student{firstmidname="peggy",lastname="justice",enrollmentdate=datetime.parse("2001-09-01")},
            //new student{firstmidname="laura",lastname="norman",enrollmentdate=datetime.parse("2003-09-01")},
            //new student{firstmidname="nino",lastname="olivetto",enrollmentdate=datetime.parse("2005-09-01")}
            //};
            //foreach (student s in students)
            //{
            //    context.students.add(s);
            //}
            //context.savechanges();

            //var courses = new course[]
            //{
            //new course{courseid=1050,title="chemistry",credits=3},
            //new course{courseid=4022,title="microeconomics",credits=3},
            //new course{courseid=4041,title="macroeconomics",credits=3},
            //new course{courseid=1045,title="calculus",credits=4},
            //new course{courseid=3141,title="trigonometry",credits=4},
            //new course{courseid=2021,title="composition",credits=3},
            //new course{courseid=2042,title="literature",credits=4}
            //};
            //foreach (course c in courses)
            //{
            //    context.courses.add(c);
            //}
            //context.savechanges();

            //var enrollments = new enrollment[]
            //{
            //new enrollment{studentid=1,courseid=1050,grade=grade.a},
            //new enrollment{studentid=1,courseid=4022,grade=grade.c},
            //new enrollment{studentid=1,courseid=4041,grade=grade.b},
            //new enrollment{studentid=2,courseid=1045,grade=grade.b},
            //new enrollment{studentid=2,courseid=3141,grade=grade.f},
            //new enrollment{studentid=2,courseid=2021,grade=grade.f},
            //new enrollment{studentid=3,courseid=1050},
            //new enrollment{studentid=4,courseid=1050},
            //new enrollment{studentid=4,courseid=4022,grade=grade.f},
            //new enrollment{studentid=5,courseid=4041,grade=grade.c},
            //new enrollment{studentid=6,courseid=1045},
            //new enrollment{studentid=7,courseid=3141,grade=grade.a},
            //};
            //foreach (enrollment e in enrollments)
            //{
            //    context.enrollments.add(e);
            //}
            //context.savechanges();
        }
    }
}