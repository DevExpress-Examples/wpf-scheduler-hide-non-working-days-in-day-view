using DevExpress.Mvvm.POCO;

namespace SchedulerDragDropExample
{
    public class PaymentState
    {
        public static PaymentState Create()
        {
            return ViewModelSource.Create(() => new PaymentState());
        }
        public static PaymentState Create(int id, string caption, string color) {        
            PaymentState psi = PaymentState.Create();
            psi.Id = id;
            psi.Caption = caption;
            psi.Color = color;
            return psi;
        }

        protected PaymentState() { }

        public virtual int Id { get; set; }
        public virtual string Caption { get; set; }
        public virtual string Color { get; set; }
    }
}