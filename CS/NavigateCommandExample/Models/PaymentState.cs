namespace SchedulerDragDropExample {
    public class PaymentState {
        public PaymentState(int id, string caption, string color) {
            Id = id;
            Caption = caption;
            Color = color;
        }

        public int Id { get; set; }
        public string Caption { get; set; }
        public string Color { get; set; }
    }
}
