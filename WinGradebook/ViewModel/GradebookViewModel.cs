using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using Gradebook.Data;
using System.ComponentModel;
using Gradebook.Core;

namespace Gradebook.ViewModel
{
    class GradebookViewModel
    {
        public SortableBindingList<StudentViewModel> Students { get; set; }
        public SortableBindingList<CourseViewModel> Courses { get; set; }
        
        private static GradebookViewModel instance;
        public static GradebookViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GradebookViewModel();
                }

                return instance;
            }
        }

        private GradebookViewModel(){
            List<Student> _students = StudentDao.getStudents();
            Students = new SortableBindingList<StudentViewModel>();
            foreach (Student student in _students)
            {
                Students.Add(new StudentViewModel(student));
            }
            
            
            List<Course> _courses = CourseDao.getCourses();
            Courses = new SortableBindingList<CourseViewModel>();
            foreach (Course course in _courses)
            {
                Courses.Add(new CourseViewModel(course));
            }
        }

        public void Save()
        {
            List<Student> _students = new List<Student>(Students.Count);
            foreach (StudentViewModel studentVM in Students)
            {
                _students.Add(new Student(studentVM));
            }

            List<Course> _courses = new List<Course>(Courses.Count);
            foreach (CourseViewModel courseVM in Courses)
            {
                _courses.Add(new Course(courseVM));
            }

            StudentDao.saveStudents(_students);
            CourseDao.saveCourses(_courses);
        }

    }
}
