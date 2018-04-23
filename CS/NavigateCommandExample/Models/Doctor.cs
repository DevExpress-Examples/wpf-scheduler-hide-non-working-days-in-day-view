#region #usings
using DevExpress.Mvvm.POCO;
using System;
#endregion #usings

namespace SchedulerDragDropExample
{
    public class Doctor
    {
        public static Doctor Create()
        {
            return ViewModelSource.Create(() => new Doctor());
        }
        public static Doctor Create(int id, string name)
        {
            Doctor doctor = Doctor.Create();
            doctor.Id = id;
            doctor.Name = name;
            return doctor;
        }

        protected Doctor() { }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}

