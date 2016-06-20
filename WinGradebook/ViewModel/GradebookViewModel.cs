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
        public SchoolYearViewModel SchoolYear { get; private set; }
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
            SchoolYear _schoolYear = SchoolYearDao.getCurrentSchoolYear();
            if (_schoolYear == null)
            {
                _schoolYear = new SchoolYear();
            }

            SchoolYear = new SchoolYearViewModel(_schoolYear);
            
            if (SchoolYear.CurrentGradingPeriod == null)
            {
                SchoolYear.CreateGradingPeriod();
            }

            GradingPeriod = SchoolYear.CurrentGradingPeriod;
        }

        public void Save()
        {
            SchoolYear schoolYear = new SchoolYear(SchoolYear);
            SchoolYearDao.SaveSchoolYear(schoolYear);
        }

    }
}
