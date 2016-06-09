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
        public SchoolYearViewModel CurrentSchoolYear { get; private set; }
        public SortableBindingList<StudentViewModel> Students {
            get
            {
                return CurrentSchoolYear.CurrentGradingPeriod.Students;
            }
        }

        public SortableBindingList<CourseViewModel> Courses
        {
            get
            {
                return CurrentSchoolYear.CurrentGradingPeriod.Courses;
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
            SchoolYear _schoolYear = SchoolYearDao.getCurrentSchoolYear();
            if (_schoolYear == null)
            {
                _schoolYear = new SchoolYear();
            }

            CurrentSchoolYear = new SchoolYearViewModel(_schoolYear);

            GradingPeriodViewModel _currentGradingPeriod = CurrentSchoolYear.CurrentGradingPeriod;
            if (CurrentSchoolYear.CurrentGradingPeriod == null)
            {
                CurrentSchoolYear.CreateGradingPeriod();
            }
        }

        public void Save()
        {
            SchoolYear schoolYear = new SchoolYear(CurrentSchoolYear);
            SchoolYearDao.SaveSchoolYear(schoolYear);
        }

    }
}
