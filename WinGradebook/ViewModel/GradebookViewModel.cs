using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradebook.Model;
using Gradebook.Data;
using System.ComponentModel;
using Gradebook.Core;
using Gradebook.ViewModel.Service;

namespace Gradebook.ViewModel
{
    public class GradebookViewModel
    {
        public List<SchoolYearViewModel> SchoolYears {get; private set; }
        public SchoolYearViewModel SchoolYear { get; set; }
        public GradingPeriodViewModel GradingPeriod { get; set; }
        public SortableBindingList<StudentViewModel> Students {
            get
            {
                return GradingPeriod.Students;
            }
        }

        public SortableBindingList<CourseViewModel> Courses
        {
            get
            {
                return GradingPeriod.Courses;
            }
        }
        
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
            GradebookModel _gradebook = GradebookDao.getGradebook();

            this.SchoolYears = new List<SchoolYearViewModel>();
            foreach (SchoolYear schoolYear in _gradebook.SchoolYears)
            {
                SchoolYearViewModel schoolYearVM = new SchoolYearViewModel(schoolYear);
                this.SchoolYears.Add(schoolYearVM);

                if (!schoolYearVM.isComplete)
                {
                    this.SchoolYear = schoolYearVM;
                }
            }

            if (this.SchoolYear == null)
            {
                this.SchoolYear = new SchoolYearViewModel();
                this.SchoolYears.Add(this.SchoolYear);
            }
            
            if (SchoolYear.CurrentGradingPeriod == null)
            {
                SchoolYear.CreateGradingPeriod();
            }

            GradingPeriod = SchoolYear.CurrentGradingPeriod;
        }

        public void Save()
        {
            GradebookModel _gradebook = new GradebookModel(this);
            GradebookDao.SaveGradebook(_gradebook);

            StateManager.Clean();
        }

        public void CreateSchoolYearFromCurrent()
        {
            this.SchoolYear.isComplete = true;
            this.SchoolYear.CurrentGradingPeriod.isComplete = true;

            SchoolYearViewModel nextSchoolYear = new SchoolYearViewModel();
            nextSchoolYear.CreateGradingPeriod();
            nextSchoolYear.CurrentGradingPeriod.Courses = cloneCourses(this.SchoolYear.CurrentGradingPeriod.Courses);

            this.SchoolYear = nextSchoolYear;
            this.SchoolYears.Add(nextSchoolYear);
            this.GradingPeriod = nextSchoolYear.CurrentGradingPeriod;
        }

        private SortableBindingList<CourseViewModel> cloneCourses(SortableBindingList<CourseViewModel> courses)
        {
            SortableBindingList<CourseViewModel> clonedCourses = new SortableBindingList<CourseViewModel>();
            foreach (CourseViewModel course in courses)
            {
                clonedCourses.Add((CourseViewModel)course.Clone());
            }

            return clonedCourses;
        }

    }
}
